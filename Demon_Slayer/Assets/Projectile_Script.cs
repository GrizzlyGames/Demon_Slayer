using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Script : MonoBehaviour {

    public float initialForce;              // Initial force when projectile is fired
    public float reduceForceAmount;         // The amount of force to reduce over time
    public float reduceForceTime;           // The rate inwhich the force is reduced over time

    [SerializeField]
    private Rigidbody rb;                   // Rigidbody to be used to apply force exposed tp projectile

    public void ShootPrimaryProjectile()           // Public funciton called by the player
    {
        InitialForce();
        Debug.Log("Shoot Projectile Function Called");
    }

    void InitialForce()
    {
        
        rb.AddForce(new Vector3(0,0,transform.localPosition.z) * initialForce);
    }

    void ReduceForce()
    {

    }

    IEnumerator ReduceForceDelay()
    {
        yield return new WaitForSeconds(reduceForceTime);           // The rate inwhich the force will be reduced
        ReduceForce();          // Call the fuction to reduce the force
    }
}
