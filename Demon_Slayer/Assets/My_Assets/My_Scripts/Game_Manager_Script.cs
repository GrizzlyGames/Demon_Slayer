using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager_Script : MonoBehaviour
{

    public static Game_Manager_Script instance;

    public GameObject playerGO;                             // Get the player GO from prefabs folder
    public GameObject dropShipGO;

    public GameObject alienOgerGO;

    public int spawnNumEnemies = 1;
    public int currentNumEnemies;

    void Awake()                                            // First function to run in scene
    {
        instance = this;                                    // This object is the only instance of Game_Controller_Script
    }

    // Use this for initialization
    void Start()
    {
        SpawnDropShip();
        Instantiate(playerGO, new Vector3(-11, 1, 1), Quaternion.Euler(0, 0, 0));         // Create player in scene
    }

    public void SpawnDropShip()
    {
        Instantiate(dropShipGO, new Vector3(-26, 500, 0), Quaternion.identity);
    }
    public void SpawnEnemy()
    {
        for (int i = 0; i < spawnNumEnemies; i++)
        {
            Instantiate(alienOgerGO, new Vector3(-26, 0, 0), Quaternion.Euler(0, 0, 0));
            currentNumEnemies++;
        }
        Debug.Log("Number of enemies: " + currentNumEnemies);
    }
}