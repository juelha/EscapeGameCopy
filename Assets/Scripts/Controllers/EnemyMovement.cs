using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;  //is attached to a mobile character in the game to allow it to navigate the Scene
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    //Patrolling
    public Vector3 walkPoint;
    private bool walkPointSet;
    public float WalkPointRange;

    //Attacking
    public float timeBtwAttacks;
    public bool attacked;

    //States
    public float sightRange, attackRange;
    public bool inSightRange, inAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;  //find player
        agent = GetComponent<NavMeshAgent>();   //assign NavMesh 

        whatIsPlayer = LayerMask.GetMask("Player");

    }

    // Update is called once per frame
    void Update()
    {


        Debug.Log("SDFGDS");
        Debug.Log(player.position);
        Debug.Log("enemy");
        Debug.Log(transform.position);

        //Check for sight and attack range
        inSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        inAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        // if player is neither in sight nor in attack range, enemy patrols
        if (!inSightRange && !inAttackRange) Patroling();
        // if player is in sight but not in attack range, enemy chases player
        if (inSightRange && !inAttackRange) ChasePlayer();
        // if player is in sight and attack range, enemy attacks player
        if (inSightRange && inAttackRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
            agent.SetDestination(walkPoint);
        //calculate distance to walk point
        Vector3 disToWalkPoint = transform.position - walkPoint;
        // if walk point is reached set walk point set to false again
        if (disToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //calculate random values in walk point range
        float randomZ = Random.Range(-WalkPointRange, WalkPointRange);
        float randomX = Random.Range(-WalkPointRange, WalkPointRange);

        // transform your position (y stays the same) to new walk point
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        // as generated point could be out of map, check if point is on the ground
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        // agent shouldn't randomly move away
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!attacked)
        {
            attacked = true;
            Invoke(nameof(ResetAttack), timeBtwAttacks);
        }
    }

    private void ResetAttack()
    {
        attacked = false;
    }
}
