using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager_Script : MonoBehaviour
{

    public static Game_Manager_Script instance;

    public GameObject playerGO;                             // Get the player GO from prefabs folder
    public GameObject dropShipGO;

    public int numberOfEnemies;

    void Awake()                                            // First function to run in scene
    {
        instance = this;                                    // This object is the only instance of Game_Controller_Script
    }

    // Use this for initialization
    void Start()
    {
        SpawnDropShip(dropShipGO);
        Instantiate(playerGO, new Vector3(1, 1, 1), Quaternion.Euler(0, 0, 0));         // Create player in scene
    }

    private void SpawnDropShip(GameObject dropShip)
    {
        Instantiate(dropShip, new Vector3(-26, 1000, 0), Quaternion.identity);
    }
    public void SpawnEnemy(GameObject enemy, int enemyNum)
    {
        for (int i = 0; i < enemyNum; i++)
            Instantiate(enemy, new Vector3(10, 0, 10), Quaternion.Euler(0, 0, 0));
        numberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log("Number of enemies: " + numberOfEnemies);
    }
}