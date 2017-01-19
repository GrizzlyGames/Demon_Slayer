using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager_Script : MonoBehaviour {

    public GameObject dropShipGO;

	// Use this for initialization
	void Start () {
        Instantiate(dropShipGO, new Vector3(-26, 1000, 0), Quaternion.identity);
	} 
}