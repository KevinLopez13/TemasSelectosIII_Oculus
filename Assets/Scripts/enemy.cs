using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    private Animator enemyControl;

    public bool walk, idle, attack, death;
    public float distance;

    public void OnTriggerEnter(Collider collider){
        if( collider.CompareTag("Bullet") ){
            idle = false;
            walk = false;
            attack = false;
            death = true;
        }
    }

    void Start(){
        target = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        enemyControl = GetComponent<Animator>();
        idle = true;
    }

    void Update(){
        this.transform.LookAt(target.transform);
        distance = Vector3.Distance(target.transform.position, this.transform.position);

        // Attack
        if( distance < 3 ){
            idle = false;
            walk = false;
            attack = true;
        }
        // walk
        else if( distance < 10 ){
            idle = false;
            walk = true;
            attack = false;
        }

        if(walk){
            agent.destination = target.position;
        }

        enemyControl.SetBool("idle", idle);
        enemyControl.SetBool("walk", walk);
        enemyControl.SetBool("attack", attack);
        enemyControl.SetBool("death", death);

        if(death)
            Destroy(this.gameObject);
    }
}
