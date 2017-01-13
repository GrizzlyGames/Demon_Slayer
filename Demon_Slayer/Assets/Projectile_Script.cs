using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Script : MonoBehaviour {
       
    public float initialForce;              // Initial force when projectile is fired
    public float increaseBulletDragAmount;         // The amount of force to reduce over time
    public float increaseDragRate;           // The rate inwhich the force is reduced over time

    [SerializeField]
    private Rigidbody rb;                   // Rigidbody to be used to apply force exposed tp projectile

    public void ShootPrimaryProjectile()           // Public funciton called by the player
    {
        InitialForce();
        // Debug.Log("Shoot Projectile Function Called");
    }

    void InitialForce()
    {        
        rb.AddForce(transform.forward * initialForce * Time.deltaTime);
        StartCoroutine("IncreaseDragDelay");
    }

    void IncreaseDrag()
    {
        rb.drag += increaseBulletDragAmount;
        StartCoroutine("IncreaseDragDelay");
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.layer != 8)
        {            
            Destroy(gameObject);
        }            
    }

    IEnumerator IncreaseDragDelay()
    {
        yield return new WaitForSeconds(increaseDragRate);           // The rate inwhich the force will be reduced
        IncreaseDrag();          // Call the fuction to reduce the force
    }
}
