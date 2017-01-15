using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player_Script : MonoBehaviour
{

    public static Player_Script instance;

    private int currentAmmo;
    private int magazineCapacity;
    private int maximumAmmo;
    private GameObject projectileGO;

    [SerializeField]
    private int health = 100;
    [SerializeField]
    private int maxHealth = 100;

    protected bool bReloading;

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
        if (Input.GetMouseButtonDown(0))
        {
            if (currentAmmo >= 1 && !bReloading)
                ShootPrimaryProjectile();
            else if (maximumAmmo < 1 && currentAmmo < 1)
                Game_Controller_Script.instance.UpdateAmmoText("No ammo!");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!bReloading && maximumAmmo > 0)
                StartCoroutine("ReloadDelay");
        }
    }

    void ShootPrimaryProjectile()
    {
        currentAmmo--;
        Game_Controller_Script.instance.UpdateAmmoText(currentAmmo.ToString() + " / " + maximumAmmo.ToString());
        GameObject go = Instantiate(Weapons_Class.instance.Projectile(), Weapons_Class.instance.ProjectileSpawnPoint().position, Weapons_Class.instance.ProjectileSpawnPoint().rotation);
        if (currentAmmo < 1 && maximumAmmo > 1 && !bReloading)
            Game_Controller_Script.instance.UpdateAmmoText("'R' to  reload");
        else if (maximumAmmo < 1 && currentAmmo < 1)
            Game_Controller_Script.instance.UpdateAmmoText("No ammo!");
    }

    public void MaxAmmoPickedUp()
    {
        maximumAmmo = GetMaximumAmmo();
        Game_Controller_Script.instance.UpdateAmmoText(currentAmmo.ToString() + " / " + maximumAmmo.ToString());
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
    public int MaximumAmmo()
    {
        return (maximumAmmo);
    }
    public int CurrentAmmo()
    {
        return (currentAmmo);
    }
    #endregion

    public int Health()
    {
        return (health);
    }
    public void DecreaseHealth(int healthAmount)
    {
        health -= healthAmount;
    }


    public int MaxHealth()
    {
        return (maxHealth);
    }

    IEnumerator ReloadDelay()
    {
        bReloading = true;
        Game_Controller_Script.instance.UpdateAmmoText("Reloading...");       
        yield return new WaitForSeconds(3);
        if (currentAmmo + maximumAmmo >= magazineCapacity)
        {
            Debug.Log("current ammo: " + currentAmmo);
            Debug.Log("max ammo: " + maximumAmmo);
            Debug.Log("after math max ammo: " + (maximumAmmo - (magazineCapacity - currentAmmo)).ToString());
            maximumAmmo = maximumAmmo - (magazineCapacity - currentAmmo);
            currentAmmo = magazineCapacity;
        }
        else if (currentAmmo + maximumAmmo < magazineCapacity)
        {
            Debug.Log("current ammo + maximum ammo is less than magazine capacity");

            Debug.Log("current ammo: " + currentAmmo);
            Debug.Log("max ammo: " + maximumAmmo);
            currentAmmo += maximumAmmo;
            maximumAmmo = 0;
        }
        Game_Controller_Script.instance.UpdateAmmoText(currentAmmo.ToString() + " / " + maximumAmmo.ToString());
        bReloading = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Max_Ammo_Pickup_Script>() != null)
            other.GetComponent<Max_Ammo_Pickup_Script>().MaxReload();
    }
}
