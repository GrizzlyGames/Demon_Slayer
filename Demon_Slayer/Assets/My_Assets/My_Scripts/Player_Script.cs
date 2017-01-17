using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class Player_Script : MonoBehaviour
{

    public static Player_Script instance;

    private int currentAmmo;
    private int magazineCapacity;
    private int maximumAmmo;
    private GameObject projectileGO;

    private float reloadDamage = 1;

    private bool bReloading;

    [SerializeField]
    private int health = 100;
    [SerializeField]
    private int maxHealth = 100;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        magazineCapacity = GetMagazineCapacity();
        currentAmmo = magazineCapacity;
        maximumAmmo = GetMaximumAmmo();

        Game_Controller_Script.instance.UpdateAmmoText(currentAmmo.ToString() + " / " + maximumAmmo.ToString());
    }

    void Update()
    {
        if (health > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentAmmo >= 1 && !bReloading)
                    ShootPrimaryProjectile();
                else if (maximumAmmo < 1 && currentAmmo < 1)
                {
                    reloadDamage = 4;
                    Game_Controller_Script.instance.UpdateAmmoText("No ammo!");
                }                    
            }

            if (Input.GetKeyUp(KeyCode.R))
            {
                if (!bReloading && maximumAmmo + currentAmmo > 0)
                {
                    if (!Game_Controller_Script.instance.ActiveReloadScrollbarState())
                    {
                        Game_Controller_Script.instance.ActiveReloadScrollbarOn(true);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (!bReloading)
                {
                    if (Game_Controller_Script.instance.ActiveReloadScrollbarState())
                    {
                        reloadDamage = Game_Controller_Script.instance.ActiveReloadScrollbar().value;

                        if (reloadDamage <= 0.2f)
                        {
                            reloadDamage = 1;
                        }
                        else if (reloadDamage > 0.2f && reloadDamage <= 0.4f)
                        {
                            reloadDamage = 2;
                        }
                        else if (reloadDamage > 0.4f && reloadDamage <= 0.6f)
                        {
                            reloadDamage = 3;
                        }
                        else if (reloadDamage > 0.6f && reloadDamage <= 0.8f)
                        {
                            reloadDamage = 2;
                        }
                        else if (reloadDamage > 0.8f)
                        {
                            reloadDamage = 1;
                        }

                        Game_Controller_Script.instance.ActiveReloadScrollbarOn(false);
                        StartCoroutine("ReloadDelay");
                    }
                }
            }



            if (Game_Controller_Script.instance.ActiveReloadScrollbarState())
                Game_Controller_Script.instance.ActiveReloadScrollbar().value = Mathf.PingPong(Time.time, 1);
        }
    }

    void ShootPrimaryProjectile()
    {
        currentAmmo--;
        Game_Controller_Script.instance.UpdateAmmoText(currentAmmo.ToString() + " / " + maximumAmmo.ToString());
        GameObject go = Instantiate(Weapons_Class.instance.Projectile(), Weapons_Class.instance.ProjectileSpawnPoint().position, Weapons_Class.instance.ProjectileSpawnPoint().rotation);
        go.GetComponent<Projectile_Script>().SetProjectileDamageMultiplier((int)reloadDamage);
        if (currentAmmo < 1 && maximumAmmo > 1 && !bReloading)
        {
            reloadDamage = 4;
            Game_Controller_Script.instance.UpdateAmmoText("'R' to  reload");
        }            
        else if (maximumAmmo < 1 && currentAmmo < 1)
        {
            reloadDamage = 4;
            Game_Controller_Script.instance.UpdateAmmoText("No ammo!");
        }
    }

    protected int GetMaximumAmmo()
    {
        return (Weapons_Class.instance.MaxAmmo());
    }
    protected int GetMagazineCapacity()
    {
        return (Weapons_Class.instance.MagazineCapacity());
    }

    #region Getters
    public Vector3 PlayerPosition()
    {
        return (transform.position);
    }
    public Transform PlayerTransform()
    {
        return (transform);
    }
    public int MaxHealth()
    {
        return (maxHealth);
    }
    public int MaximumAmmo()
    {
        return (maximumAmmo);
    }
    public int CurrentAmmo()
    {
        return (currentAmmo);
    }
    #endregion

    public int ReturnReloadDamage()
    {
        return ((int)reloadDamage);
    }

    public int Health()
    {
        return (health);
    }
    public void DecreaseHealth(int healthAmount)
    {
        health -= healthAmount;
        if (health <= 0)
        {
            gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            Game_Controller_Script.instance.UpdateMessageText("GAME OVER");
        }
    }

    IEnumerator ReloadDelay()
    {
        bReloading = true;
        Game_Controller_Script.instance.UpdateAmmoText("Reloading...");

        yield return new WaitForSeconds(reloadDamage);

        if (currentAmmo + maximumAmmo >= magazineCapacity)
        {
            maximumAmmo = maximumAmmo - (magazineCapacity - currentAmmo);
            currentAmmo = magazineCapacity;
        }
        else if (currentAmmo + maximumAmmo < magazineCapacity)
        {
            currentAmmo += maximumAmmo;
            maximumAmmo = 0;
        }
        Game_Controller_Script.instance.UpdateAmmoText(currentAmmo.ToString() + " / " + maximumAmmo.ToString());
        bReloading = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("MaxAmmo"))
        {
            maximumAmmo = GetMaximumAmmo();
            Game_Controller_Script.instance.UpdateAmmoText(currentAmmo.ToString() + " / " + maximumAmmo.ToString());
        }

        if (other.gameObject.tag.Equals("MaxHealth"))
        {
            Debug.Log("Max health pickup");
            health = maxHealth;
            Game_Controller_Script.instance.UpdateHealthScrollbar();
        }
    }
}
