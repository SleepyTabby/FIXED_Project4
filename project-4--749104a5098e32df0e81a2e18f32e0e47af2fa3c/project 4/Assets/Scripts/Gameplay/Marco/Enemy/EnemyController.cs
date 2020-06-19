using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    roaming,
    attacking
};
public class EnemyController : MonoBehaviour
{
    public EnemyshootingScript shoot;

    [Header("agentSettings")]
    [SerializeField] Transform target;
    public int health = 50;
    NavMeshAgent agent;
    [SerializeField] float normalMovementSpeed = 7;
    [Header("roamingSettings")]
    [Range(0.5f, 5f)]
    [SerializeField] float roamingSpeed;
    [SerializeField] Transform[] RoamSpots;
    int randomSpots;
    [SerializeField] float waitTime;
    [SerializeField] float startWaitTime;
    [Header("currentState")]
    [SerializeField] public EnemyState state;
    //zelda style
    [SerializeField] private GameObject SearchingLight;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetNextRoamingDestination();
        agent.speed = roamingSpeed;
        agent.stoppingDistance = 0;

        waitTime = startWaitTime;
    }

    public void SetNextRoamingDestination()
    {
        float checker = randomSpots;
        randomSpots = Random.Range(0, RoamSpots.Length);
        if(checker != randomSpots)
        {
            Vector3 RoamPos = new Vector3(RoamSpots[randomSpots].position.x, transform.position.y, RoamSpots[randomSpots].position.z);
            agent.SetDestination(RoamPos);
        }
        else
        {
            randomSpots = Random.Range(0, RoamSpots.Length);
            Vector3 RoamPos = new Vector3(RoamSpots[randomSpots].position.x, transform.position.y, RoamSpots[randomSpots].position.z);
            agent.SetDestination(RoamPos);
        }
    }

    public void LoseSomeHealth(int hp)
    {
        health -= hp;
        FindObjectOfType<PlayerStatistics>().AmountOfBulletsHit++;
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            //bertan
            FindObjectOfType<PlayerStatistics>().Kills++;
            //
        }

        if (state == EnemyState.attacking)
        {
            agent.SetDestination(target.position);

            agent.stoppingDistance = 3f;

            agent.speed = normalMovementSpeed;

            FaceTarget();

            shoot.ShootAtPlayer();
        }
        if (state == EnemyState.roaming)
        {
            agent.speed = roamingSpeed;

            agent.stoppingDistance = 0f;

            Vector3 RoamPos = new Vector3(RoamSpots[randomSpots].position.x, transform.position.y, RoamSpots[randomSpots].position.z);

            agent.SetDestination(RoamPos);
        
            if (transform.position == RoamPos)
            {
                if (waitTime <= 0)
                {
                    SetNextRoamingDestination();
                    waitTime = startWaitTime;
                }
                else if (waitTime > 0)
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }


    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

}
