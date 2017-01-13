using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Projectile_Script : MonoBehaviour {

    public GameObject projectile;           // Get projectile to be fired

    [SerializeField]
    private Transform projectileSpawnPoint;

    private Projectile_Script projectileScript;

    public void ShootPrimaryProjectile()           // Public funciton called by the player
    {
        // Debug.Log("Shoot Projectile Called");

        GameObject go = Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        projectileScript = go.GetComponent(typeof(Projectile_Script)) as Projectile_Script;

        projectileScript.ShootPrimaryProjectile();         // Call the function ShootPrjectile attached to the Projectile Gameobject
    }
}
