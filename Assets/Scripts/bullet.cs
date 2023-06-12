using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float distance;

    public void OnCollisionEnter(Collision collision){
        if( collision.gameObject.tag == "Wall")
            Destroy(this.gameObject);
    }

    void Update()
    {
        this.transform.LookAt(Vector3.zero);
        distance = Vector3.Distance(Vector3.zero, this.transform.position);

        if (distance > 20)
            Destroy(this.gameObject);
    }
}
