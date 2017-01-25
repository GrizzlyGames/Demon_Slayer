using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Alien_Oger_Script : MonoBehaviour {

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private NavMeshAgent navMeshAgent;

    Chase_Player chasePlayerScript;

	// Use this for initialization
	void Start () {
        chasePlayerScript = GetComponent<Chase_Player>();
        anim = GetComponent<Animator>();
	}

    void FixedUpdate()
    {
        // Debug.Log("Nav Speed: " + Vector3.Project(navMeshAgent.desiredVelocity, transform.forward).magnitude);
        float movementSpeed = Vector3.Project(navMeshAgent.desiredVelocity, transform.forward).magnitude;

        if(GetComponent<Chase_Player>().canWalk)
        anim.SetFloat("speed", movementSpeed);

        if(movementSpeed < 1){
            StartCoroutine(CanWalkDelay());
        }
        
    }

    public void AlienHit()
    {
        int rndNum = Random.Range(1, 3);

        switch (rndNum){
            case 1:
                anim.SetTrigger("hit1");
                break;
            default:
                anim.SetTrigger("hit2");
                break;
        }            
    }
    public void AlienKilled()
    {
        anim.SetTrigger("death");
    }

    IEnumerator CanWalkDelay()
    {
        GetComponent<Chase_Player>().canWalk = false;
        yield return new WaitForSeconds(4);
        GetComponent<Chase_Player>().canWalk = true;
    }
}
