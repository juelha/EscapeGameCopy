using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;


public class EnemyController : MonoBehaviour
{
    float lookRange = 10f;
    
    public NavMeshAgent agent;  //is attached to a mobile character in the game to allow it to navigate the Scene
    public Transform target;
    private PlayerManager playerInst;
    
    // Start is called before the first frame update
    void Start()
    {
        playerInst = PlayerManager.Instance;
        agent = GetComponent<NavMeshAgent>();
        target = playerInst.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //get distance btw enemy and player at given time
        float distance = Vector3.Distance(target.position, transform.position);
        // if enemy can see the player, start chase
        if (distance <= lookRange)
        {
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                //attack the target
                
                FaceTarget();
            }
        }
    }

    void FaceTarget()
    {
        // get direction where to face
        Vector3 direction = (target.position - transform.position).normalized;
        // get rotation to that direction
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        // update own position
        transform.rotation = lookRotation;  // could smooth this with Quaternion.Slerp(transform.rotation, lookRotation, time.deltaTime * 5f);
    }
}
