using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    
    public GameObject enemy;
    public GameObject[] spaws;
    public int sapw_index = 0;

    void Update()
    {   

        if( GameObject.FindGameObjectsWithTag("Enemy").Length < 3 ){
            var enmy = Instantiate(enemy, spaws[sapw_index++].transform.position, Quaternion.identity );
        }

        if(sapw_index >= spaws.Length)
            sapw_index = 0;
    }
}
