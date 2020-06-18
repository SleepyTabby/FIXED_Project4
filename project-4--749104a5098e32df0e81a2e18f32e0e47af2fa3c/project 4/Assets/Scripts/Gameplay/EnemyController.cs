﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    public EnemyshootingScript shoot;

    [Header("agentSettings")]
    [SerializeField] float lookRadius = 10f;
    [SerializeField] Transform target;
    public int health = 50;
    NavMeshAgent agent;
    [SerializeField] float normalMovementSpeed = 7;
    [Header("roamingSettings")]
    [Range(0.5f, 5f)]
    [SerializeField] float roamingSpeed;
    [SerializeField] Transform[] RoamSpots;
    int randomSpots;
    [SerializeField] bool roaming;
    [SerializeField] float waitTime;
    [SerializeField] float startWaitTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        randomSpots = Random.Range(0, RoamSpots.Length);
        if (roaming)
        {
agent.SetDestination(RoamSpots[randomSpots].position);
        }
        
        waitTime = startWaitTime;
    }

    public void LoseSomeHealth(int hp)
    {
        health -= hp;
        FindObjectOfType<PlayerStatistics>().AmountOfBulletsHit++;
    }

    void Update()
    {
        //float distance = Vector3.Distance(target.position, transform.position);

        if (health <= 0)
        {
            Destroy(this.gameObject);
            FindObjectOfType<PlayerStatistics>().Kills++;
        }

        //if (distance <= lookRadius)
        //{
        //    agent.SetDestination(target.position);
        //    FaceTarget();
        //}
        //if (distance <= agent.stoppingDistance)
        //{
        //    shoot.ShootAtPlayer();
        //}
        // maak enums 


        if (roaming)
        {
            Vector3 RoamPos = new Vector3(RoamSpots[randomSpots].position.x, transform.position.y, RoamSpots[randomSpots].position.z);
            agent.speed = roamingSpeed;
            //agent.SetDestination(RoamPos);
            if (Vector3.Distance(transform.position, RoamPos) < 0.2f)
            {
                Debug.Log("ye");
                if (waitTime <= 0)
                {
                    randomSpots = Random.Range(0, RoamSpots.Length);
                    agent.SetDestination(RoamSpots[randomSpots].position);
                    waitTime = startWaitTime;
                }
                else if (waitTime > 0)
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
        else
        {
            agent.speed = normalMovementSpeed;
        }
    }


    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}
