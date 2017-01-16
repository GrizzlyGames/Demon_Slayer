using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage_Script : MonoBehaviour {

    [SerializeField]
    private Animator anim;

    public int health;

    void Start()
    {
        if(anim == null)
        anim = GetComponent<Animator>();
    }

    public void Damage(int damage)
    {
        health -= damage;
        anim.SetTrigger("Hurt");
        if (health <= 0) {
            Destroy(gameObject);                    // Debug.Log("Monster health: " + health);
        }
    }
}
