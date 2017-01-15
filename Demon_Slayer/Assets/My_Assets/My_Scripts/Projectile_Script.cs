using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Script : MonoBehaviour {
       
    public float initialForce;              // Initial force when projectile is fired
    public int projectileDamage;            // The amount of damage the projectile will produce

    [SerializeField]
    private Rigidbody rb;                   // Rigidbody to be used to apply force exposed tp projectile

    void Start()
    {
        if(rb == null)
        rb = GetComponent(typeof(Rigidbody)) as Rigidbody;
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * initialForce * Time.deltaTime);
    }

    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);

        if (col.gameObject.GetComponent<TakeDamage_Script>() != null)
        {
            col.gameObject.GetComponent<TakeDamage_Script>().Damage(projectileDamage);
        }
    }
}
