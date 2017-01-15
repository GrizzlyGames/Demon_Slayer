using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Chase_Player : MonoBehaviour {

    public Animator anim;

    [SerializeField]
    private NavMeshAgent navMeshAgent;

    [SerializeField]
    private float attackDistence = 2;

    private bool bAttacking = false;

    void Start()
    {
        if(navMeshAgent == null)
        navMeshAgent = GetComponent<NavMeshAgent>();

        bAttacking = false;
    }
    void Update()
    {
        navMeshAgent.destination = Player_Script.instance.PlayerPosition();

        transform.LookAt(Player_Script.instance.PlayerTransform());

        // Debug.Log("enemy distence from player: " + Vector3.Distance(Player_Script.instance.PlayerPosition(), transform.position));

        if (Vector3.Distance(Player_Script.instance.PlayerPosition(), transform.position) <= attackDistence && !bAttacking)
        {
            StartCoroutine("AttackDelay");
        }
    }

    IEnumerator AttackDelay()
    {
        anim.SetTrigger("Attack");
        bAttacking = true;
        Game_Controller_Script.instance.UpdateHealthScrollbar(10);
        yield return new WaitForSeconds(1);        
        bAttacking = false;
    }
}
