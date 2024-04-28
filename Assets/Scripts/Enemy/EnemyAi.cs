using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    GameObject player;

    NavMeshAgent agent;
    
    //To know which object is the ground and if object in range is the player
    [SerializeField] LayerMask groundLayer, playerLayer;
    
    
    //Patrolling
    //Point we talk towards
    Vector3 destPoint;
    //Tells the game if the enemy has a destination and is walking towards there
    private bool walkPointSet;
    //How far he can go 
    [SerializeField] private float range;
    
    //State change 
    [SerializeField] private float sightRange, attackRange;
    private bool playerInSight, playerInAttackRange;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("PlayerTank");
    }

    // Update is called once per frame
    void Update()
    {
        //Check in a sphere a location with a certain radius if its going to find an object in specific layer
        //If it finds anything in PlayerLayer in certain sight range around player transform
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if (!playerInSight && !playerInAttackRange) Patrol();
        if (playerInSight && !playerInAttackRange) Chase();
    }

    void Patrol()
    {
        if (!walkPointSet) SearchForDest();
        if (walkPointSet) agent.SetDestination(destPoint);
        if (Vector3.Distance(transform.position, destPoint) < 10) walkPointSet = false;
    }

    void Chase()
    {
        agent.SetDestination(player.transform.position);
    }
    void SearchForDest()
    {
        //Picks random Z and X value
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        //Check if it's a viable location to walk towards
        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkPointSet = true;
        }
    }
}