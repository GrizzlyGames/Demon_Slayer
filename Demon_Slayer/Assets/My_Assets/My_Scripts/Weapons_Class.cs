using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Weapons_Class : MonoBehaviour {

    public static Weapons_Class instance;

    [SerializeField]
    private int maximumAmmo;
    [SerializeField]
    private int magazineCapacity;

    public GameObject projectileGO;

    public Transform projectileSpawnPoint;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (maximumAmmo <= 0)
            maximumAmmo = 24;
        if (magazineCapacity <= 0)
            magazineCapacity = 12;
    }

    public int MaxAmmo()
    {
        return (maximumAmmo);
    }
    public int MagazineCapacity()
    {
        return (magazineCapacity);
    }
    public Transform ProjectileSpawnPoint()
    {
        return (projectileSpawnPoint);
    }
    public GameObject Projectile()
    {
        return (projectileGO);
    }
}
