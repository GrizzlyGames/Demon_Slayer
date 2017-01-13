using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour {

    [SerializeField]
    GameObject weaponHolder;

    private Shoot_Projectile_Script shootProjectileScript;          // Holds the script Shoot_Projectile_Script from the projectile Gameobject

	// Use this for initialization
	void Start () {
        if(weaponHolder == null)
        weaponHolder = gameObject.transform.GetChild(1).gameObject;

        GetShootProjectileScript();         // Call GetShootProjectileScript      
	}

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootPrimaryProjectile();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            shootProjectileScript.ReloadWeapon();
        }

    }

    void GetShootProjectileScript()         // Gets the script attached to the weapon in the weapon holder
    {
        shootProjectileScript = weaponHolder.GetComponentInChildren(typeof(Shoot_Projectile_Script)) as Shoot_Projectile_Script;        // Gets the script Shoot_Projectile_Script from the projectile Gameobject
        // Debug.Log(shootProjectileScript.name);      // Name of weapon in weapon holder
    }

    void ShootPrimaryProjectile()
    {
        shootProjectileScript.ShootPrimaryProjectile();        // Call the function ShootPrimaryProjectile from the Shoot Projectile Script
    }
}
