using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyshootingScript : MonoBehaviour
{
    
    [SerializeField] GameObject player;

    [SerializeField] private float TimeBetweenShots;
    [SerializeField] private float startTimeBetweenShots;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform firingPoint;

    void Start()
    {
        TimeBetweenShots = startTimeBetweenShots;
    }

    void Update()
    {
        
    }
    public void ShootAtPlayer()
    {
        if (TimeBetweenShots <= 0)
        {

            Instantiate(projectile, firingPoint.position, firingPoint.rotation);
            TimeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            TimeBetweenShots -= Time.deltaTime;
        }
    }

}
