﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum BossStage
{
    Waiting,
    StageOne,
    StageTwo, 
    StageThree,
    StageFour
}

public class Boss : MonoBehaviour
{
    [Header("BossHealth")]
    [SerializeField] float healthBarAmountOne;
    [SerializeField] float healthBarAmountTwo;
    [SerializeField] float healthBarAmountThree;
    [SerializeField] float healthBarAmountFour;
    [SerializeField] float healthRegen;
    //[Header("BossHealth")]
    //[SerializeField] HealthbarEnemy 
    [Header("CurrentBossStage")]
    [SerializeField] BossStage currentStage;
    NavMeshAgent agent;
    [Header("SchootSettings")]
    [SerializeField] private float TimeBetweenShots;
    [SerializeField] private float fireSpeed;
    [SerializeField] private Transform[] centralFiringPoints;
    [SerializeField] private Transform[] UnevencentralFiringPoints;
    [SerializeField] private Transform[] SlightcentralFiringPoints;
    [SerializeField] private GameObject projectile;
    //[Range(0, 16)] 
    //[SerializeField] private int fireingAngle;
    [Header("RunPrevention")]
    [SerializeField] private GameObject FallingDebris;
    [Header("movement")]
    [SerializeField] private float stoppingDistance;
    [SerializeField] private float movementSpeed;
    [Header("SchootPattern")]
    [SerializeField] int patternInUse;
    [SerializeField] float fireingSpeedIncrease;
    [SerializeField] int[] patternsStageOne;
    [SerializeField] int[] patternsStageTwo;
    [SerializeField] int[] patternsStageThree;
    [SerializeField] int[] patternsStageFour;

    void Start()
    {
        currentStage = BossStage.Waiting;
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        PatternOne();
    }
    public bool E;
    void PatternOne()
    {
        if (E)
        {
            if (TimeBetweenShots + fireSpeed <= Time.time)
            {
                //even
                Instantiate(projectile, centralFiringPoints[0].position, centralFiringPoints[0].rotation);
                Instantiate(projectile, centralFiringPoints[1].position, centralFiringPoints[1].rotation);
                Instantiate(projectile, centralFiringPoints[2].position, centralFiringPoints[2].rotation);
                Instantiate(projectile, centralFiringPoints[3].position, centralFiringPoints[3].rotation);
                Instantiate(projectile, centralFiringPoints[4].position, centralFiringPoints[4].rotation);
                Instantiate(projectile, centralFiringPoints[5].position, centralFiringPoints[5].rotation);
                Instantiate(projectile, centralFiringPoints[6].position, centralFiringPoints[6].rotation);
                Instantiate(projectile, centralFiringPoints[7].position, centralFiringPoints[7].rotation);
                //uneven
                Instantiate(projectile, UnevencentralFiringPoints[0].position, UnevencentralFiringPoints[0].rotation);
                Instantiate(projectile, UnevencentralFiringPoints[1].position, UnevencentralFiringPoints[1].rotation);
                Instantiate(projectile, UnevencentralFiringPoints[2].position, UnevencentralFiringPoints[2].rotation);
                Instantiate(projectile, UnevencentralFiringPoints[3].position, UnevencentralFiringPoints[3].rotation);
                Instantiate(projectile, UnevencentralFiringPoints[4].position, UnevencentralFiringPoints[4].rotation);
                Instantiate(projectile, UnevencentralFiringPoints[5].position, UnevencentralFiringPoints[5].rotation);
                Instantiate(projectile, UnevencentralFiringPoints[6].position, UnevencentralFiringPoints[6].rotation);
                Instantiate(projectile, UnevencentralFiringPoints[7].position, UnevencentralFiringPoints[7].rotation);
                TimeBetweenShots = Time.time; 
                //slight
                Instantiate(projectile, SlightcentralFiringPoints[0].position, SlightcentralFiringPoints[0].rotation);
                Instantiate(projectile, SlightcentralFiringPoints[1].position, SlightcentralFiringPoints[1].rotation);
                Instantiate(projectile, SlightcentralFiringPoints[2].position, SlightcentralFiringPoints[2].rotation);
                Instantiate(projectile, SlightcentralFiringPoints[3].position, SlightcentralFiringPoints[3].rotation);
                Instantiate(projectile, SlightcentralFiringPoints[4].position, SlightcentralFiringPoints[4].rotation);
                Instantiate(projectile, SlightcentralFiringPoints[5].position, SlightcentralFiringPoints[5].rotation);
                Instantiate(projectile, SlightcentralFiringPoints[6].position, SlightcentralFiringPoints[6].rotation);
                Instantiate(projectile, SlightcentralFiringPoints[7].position, SlightcentralFiringPoints[7].rotation);
                Instantiate(projectile, SlightcentralFiringPoints[8].position, SlightcentralFiringPoints[8].rotation);
                Instantiate(projectile, SlightcentralFiringPoints[9].position, SlightcentralFiringPoints[9].rotation);
                Instantiate(projectile, SlightcentralFiringPoints[10].position, SlightcentralFiringPoints[10].rotation);
                Instantiate(projectile, SlightcentralFiringPoints[11].position, SlightcentralFiringPoints[11].rotation);
                Instantiate(projectile, SlightcentralFiringPoints[12].position, SlightcentralFiringPoints[12].rotation);
                Instantiate(projectile, SlightcentralFiringPoints[13].position, SlightcentralFiringPoints[13].rotation);
                Instantiate(projectile, SlightcentralFiringPoints[14].position, SlightcentralFiringPoints[14].rotation);
                Instantiate(projectile, SlightcentralFiringPoints[15].position, SlightcentralFiringPoints[15].rotation);
                E = false;
            }
    }
}
}
