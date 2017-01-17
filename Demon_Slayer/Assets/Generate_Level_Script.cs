using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_Level_Script : MonoBehaviour
{
    public int rows;
    public int cols;
    public GameObject GO;

    // Use this for initialization
    void Start()
    {
        GenerateGround();
    }

    void GenerateGround()
    {
        for (int x = 0; x <= rows; x++)
        {
            for (int y = 0; y <= cols; y++)
            {
                GameObject go = Instantiate(GO, new Vector3(x * 2, y * 2, 0), Quaternion.identity) as GameObject;
                go.transform.parent = transform;
            }
        }
    }
}
