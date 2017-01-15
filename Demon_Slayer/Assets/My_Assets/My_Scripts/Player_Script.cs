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

        Game_Controller_Script.instance.UpdateAmmoText();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootPrimaryProjectile();

            /*
            if (currentAmmo > 0 && !bReloading)
                ShootPrimaryProjectile();
            else
                StartCoroutine("ReloadDelay");
            */
        }
    }

    void ShootPrimaryProjectile()
    {
        currentAmmo--;        
        Game_Controller_Script.instance.UpdateAmmoText();
        GameObject go = Instantiate(Weapons_Class.instance.Projectile(), Weapons_Class.instance.ProjectileSpawnPoint().position, Weapons_Class.instance.ProjectileSpawnPoint().rotation);
    }

    public void MaxAmmoPickedUp()
    {
        maximumAmmo = GetMaximumAmmo();
        Game_Controller_Script.instance.UpdateAmmoText();
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

    IEnumerator ReloadDelay()
    {
        bReloading = true;
        maximumAmmo = magazineCapacity - currentAmmo;
        yield return new WaitForSeconds(3);
        currentAmmo = magazineCapacity;
        Game_Controller_Script.instance.UpdateAmmoText();
        bReloading = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Max_Ammo_Pickup_Script>() != null)
            other.GetComponent<Max_Ammo_Pickup_Script>().MaxReload();
    }
}
