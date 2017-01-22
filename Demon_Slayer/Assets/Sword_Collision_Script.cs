using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_Collision_Script : MonoBehaviour {

    public int Damage = 100;

    void OnTriggerEneter(Collider col)
    {
        Debug.Log("Sword hit " + col.transform.name);
        if (col.gameObject.GetComponent<TakeDamage_Script>() != null)
        {
            col.gameObject.GetComponent<TakeDamage_Script>().Damage(Damage);
            Debug.Log("Sword gave damage");
        }
    }
}
