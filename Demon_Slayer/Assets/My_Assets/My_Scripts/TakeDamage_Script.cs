using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage_Script : MonoBehaviour {

    public int health;

    public void Damage(int damage)
    {
        health -= damage;
        // Debug.Log("Monster health: " + health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
