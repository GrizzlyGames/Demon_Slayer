using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Chase_Player : MonoBehaviour {

    [SerializeField]
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        if(navMeshAgent == null)
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        navMeshAgent.destination = Player_Script.instance.PlayerPosition();
        transform.LookAt(Player_Script.instance.PlayerTransform());
    }
}
