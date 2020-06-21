using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    roaming,
    attacking,
    gettingShot
};
public class EnemyController : MonoBehaviour
{
    public EnemyshootingScript shoot;

    [Header("agentSettings")]
    [SerializeField] Transform target;
    NavMeshAgent agent;
    [SerializeField] float normalMovementSpeed = 7;
    [Header("roamingSettings")]
    [Range(0.5f, 5f)]
    [SerializeField] float roamingSpeed;
    [SerializeField] Transform[] RoamSpots;
    int randomSpots;
    [SerializeField] float waitTime;
    [SerializeField] float startWaitTime;
    [SerializeField] float waitLoseTime;
    [SerializeField] float startLoseWaitTime = 5;
    [Header("currentState")]
    [SerializeField] public EnemyState state;
    //zelda style
    [SerializeField] private GameObject SearchingLight;
    public int Enemyhealth = 50;
    public EnemyHealthBar enemyHealth;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetNextRoamingDestination();
        agent.speed = roamingSpeed;
        agent.stoppingDistance = 0;
        enemyHealth.SetEnemyMaxHealth(Enemyhealth);

        waitTime = startWaitTime;
        waitLoseTime = startLoseWaitTime;
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

    void Update()
    {
        if (Enemyhealth <= 0)
        {
            Destroy(this.gameObject);
        }

        if (state == EnemyState.gettingShot)
        {
            if (waitLoseTime <= 0)
            {
                state = EnemyState.roaming;
                waitLoseTime = startLoseWaitTime;
            }
            else if (waitLoseTime > 0)
            {
                waitLoseTime -= Time.deltaTime;
            }
        }
        if (state == EnemyState.attacking|| state == EnemyState.gettingShot)
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
