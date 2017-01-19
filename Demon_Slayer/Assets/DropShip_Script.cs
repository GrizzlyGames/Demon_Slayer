using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropShip_Script : MonoBehaviour
{
    public GameObject healthPickUpGO;
    public GameObject ammoPickUpGO;
    
    private bool descending = true;

    private int descendSpeed = 50;
    private int ascendingSpeed = 25;

    void Update()
    {
        if (transform.position.y > 4 && descending)
        {
            if (transform.position.y < 17)
                descendSpeed = 5;
            transform.Translate(Vector3.up * -descendSpeed * Time.deltaTime);
            if (transform.position.y <= 4)
                StartCoroutine("DescendingDelay");
        }
        else if (!descending)
        {
            if (transform.position.y > 17)
                descendSpeed = 50;
            transform.Translate(Vector3.up * ascendingSpeed * Time.deltaTime);
            if (transform.position.y > 1000)
                Destroy(gameObject);
        }
    }

    IEnumerator DescendingDelay()
    {
        Instantiate (healthPickUpGO, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
        Instantiate(ammoPickUpGO, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(3);
        descending = false;
    }
}
