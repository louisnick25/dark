using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    private Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public static float health;
    //Patrol
    public Vector3 walkpoint;
    bool walkPointSet;
    public float walkPointRange;
    //attack
    public float timeBetweenAttack;
    bool alreadyAttacks;
    public GameObject projectile;
    public GameObject charmobject;
    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public float enemyhp;
    public float weapon;


      

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        playerInSightRange= Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange ) ChasePlayer();
       // Invoke(nameof(ChasePlayer), 15f);
        //print(Time.deltaTime);
        if (playerInSightRange && playerInAttackRange) AttackPlayer();

    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkpoint);

        Vector3 distanceToWalkPoint = transform.position - walkpoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkpoint = new Vector3(transform.position.x + randomX, transform.position.z + randomZ);

        if (Physics.Raycast(walkpoint, transform.up, whatIsGround))
          walkPointSet = true;
    }
    private void ChasePlayer()
    {
        
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);
        if (!alreadyAttacks)
        {

            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            alreadyAttacks = true;
            Invoke(nameof(ResetAttack), timeBetweenAttack);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacks = false;
    }
   /* public void TakeDamage(int damage)
    {
        health = -damage;
        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5F);
    }*/
    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    public void charm()
    {
        Invoke("Patroling", 5);
       // agent.SetDestination(player.position);

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("weapon"))
        {
            Debug.Log("hit");
            print("hit");
            TakeDamage();
            
        }
    }
    public static void  TakeDamage()
    {
        Debug.Log("hit");
        print("hit");
        enemy.health -= 10f;
        if (health <= 0)
        {
            Destroy(GameObject.Find("Enemy"));
        }
    }
    
 }