using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Transform posArma;
    public GameObject bullet;
    public gameController gameController;
    public float force = 40.0f;
    public int health = 5;
    public Transform originPos;

    public void restart(){
        this.gameObject.transform.SetPositionAndRotation( originPos.position, originPos.rotation);
    }

    public void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Damage")){
            Debug.LogWarning("Auch!!");
            if( health-- < 0 )
                gameController.lost();
        }

        if( collider.CompareTag("Goal") ){
            gameController.win();
        }
    }

    void Update()
    {   
        if( OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.M)){
            var bullets = Instantiate(bullet, posArma.position, Quaternion.identity);
            var rb = bullets.GetComponent<Rigidbody>();
            rb.AddForce(posArma.transform.forward * force, ForceMode.Impulse);
        }
    }
}
