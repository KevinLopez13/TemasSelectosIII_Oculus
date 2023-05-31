using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public Animator enemyControl;
    public bool walk, idle, attack, death;

    public void OnTriggerEnter(Collider collider){
        if(collider.gameObject.name == "Player")
            walk = true;
    }

    void Start(){
        agent = GetComponent<NavMeshAgent>();
        enemyControl = GetComponent<Animator>();
    }

    void Update(){
        if(walk)
            agent.destination = target.position;

        enemyControl.SetBool("idle", idle);
        enemyControl.SetBool("walk", walk);
        enemyControl.SetBool("attack", attack);
        enemyControl.SetBool("death", death);   
    }
}
