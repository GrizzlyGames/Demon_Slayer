using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shoot_Projectile_Script : MonoBehaviour {

    public GameObject projectile;           // Get projectile to be fired

    public int maxAmmo;

    public Text AmmoText;

    [SerializeField]
    private Transform projectileSpawnPoint;

    private Projectile_Script projectileScript;

    private int shotsFired;
    private bool bReloading;

    void Start()
    {
        if(projectileSpawnPoint == null)
        projectileSpawnPoint = gameObject.transform.GetChild(0).transform;

        AmmoText.text = maxAmmo.ToString() + " / " + maxAmmo.ToString();
    }

    public void ShootPrimaryProjectile()           // Public funciton called by the player
    {        
        if (!bReloading)
        {
            GameObject go = Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            projectileScript = go.GetComponent(typeof(Projectile_Script)) as Projectile_Script;

            projectileScript.ShootPrimaryProjectile();         // Call the function ShootPrjectile attached to the Projectile Gameobject
            shotsFired++;
            AmmoText.text = (maxAmmo - shotsFired).ToString() + " / " + maxAmmo.ToString();
            Debug.Log("Num of shots fired: " + shotsFired);
            if (shotsFired >= maxAmmo)
            {
                ReloadWeapon();
            }
        }        
    }

    public void ReloadWeapon()
    {
        AmmoText.text = "Reloading...";
        bReloading = true;
        StartCoroutine("ReloadDelay");
    }

    IEnumerator ReloadDelay()
    {
        yield return new WaitForSeconds(3);
        shotsFired = 0;
        AmmoText.text = maxAmmo.ToString() + " / " + maxAmmo.ToString();
        bReloading = false;
    }
}
