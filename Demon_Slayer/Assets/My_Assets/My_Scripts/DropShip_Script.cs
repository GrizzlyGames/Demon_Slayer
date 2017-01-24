using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropShip_Script : MonoBehaviour
{ 
    public GameObject enemyGO;

    public GameObject healthPickUpGO;
    public GameObject ammoPickUpGO;
    
    private bool descending = true;

    private int descendSpeed = 100;
    private int ascendingSpeed = 25;

    void Update()
    {
        if (transform.position.y > 5 && descending)
        {
            if (transform.position.y < 101 && transform.position.y > 17)
                descendSpeed = 25;
            else if (transform.position.y <= 17)
                descendSpeed = 3;
            transform.Translate(Vector3.up * -descendSpeed * Time.deltaTime);
            if (transform.position.y <= 5)
                StartCoroutine("DescendingDelay");
        }
        else if (!descending)
        {           
            if (transform.position.y > 17)
                ascendingSpeed = 250;

            transform.Translate(Vector3.up * ascendingSpeed * Time.deltaTime);

            if (transform.position.y > 1000)
            {
                Game_Manager_Script.instance.SpawnEnemy(enemyGO);
                Game_Manager_Script.instance.spawnNumEnemies = Game_Manager_Script.instance.spawnNumEnemies * 2;
                Destroy(gameObject);
            }                
        }
    }

    IEnumerator DescendingDelay()
    {
        Instantiate (healthPickUpGO, new Vector3(transform.position.x - 1, transform.position.y - 3.5f, transform.position.z), Quaternion.identity);
        Instantiate(ammoPickUpGO, new Vector3(transform.position.x + 1, transform.position.y - 3.5f, transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(3);
        descending = false;
    }
}
