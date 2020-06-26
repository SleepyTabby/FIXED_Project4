using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum BossStage
{
    Waiting,
    detectedPlayer,
    StageOne,
    StageTwo, 
    StageThree,
    StageFour
}

public class Boss : MonoBehaviour
{
    [Header("BossHealth")]
    [SerializeField] float healthRegen;
    //[Header("BossHealth")]
    //[SerializeField] HealthbarEnemy 
    [Header("CurrentBossStage")]
    [SerializeField] BossStage currentStage;
    public BossHealthBar bossHealth;
    bool startBossBattle;
    NavMeshAgent agent;
    [Header("SchootSettings")]
    [SerializeField] private float TimeBetweenShots;
    [SerializeField] private float fireSpeed;
    [SerializeField] private Transform[] centralFiringPoints;
    [SerializeField] private Transform[] UnevencentralFiringPoints;
    [SerializeField] private Transform[] SlightcentralFiringPoints;
    [SerializeField] private GameObject projectile;
    [SerializeField] Transform target;
    //[Range(0, 16)] 
    //[SerializeField] private int fireingAngle;
    [Header("RunPrevention")]
    [SerializeField] private GameObject FallingDebris;
    [Header("movement")]
    [SerializeField] private float stoppingDistance;
    [SerializeField] private float movementSpeed;
    [Header("SchootPattern")]
    [SerializeField] int patternInUse;
    int RandomNumber = 32;
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
    int count;
    private void Update()
    {
        if (startBossBattle)
        {
            FaceTarget();
        }
        if(currentStage == BossStage.detectedPlayer)
        {
            startBossBattle = true;
        }
        if (startBossBattle)
        {
            FaceTarget();
            agent.SetDestination(target.position);
        }
        if (bossHealth.BossHealthsliderOne.value >= 0)
        {
            currentStage = BossStage.StageOne;

        }
        if (bossHealth.BossHealthsliderTwo.value >= 0 && bossHealth.BossHealthsliderOne.value <= 0)
        {
            currentStage = BossStage.StageTwo;
        }
        if (bossHealth.BossHealthsliderTwo.value <= 0 && bossHealth.BossHealthsliderOne.value <= 0)
        {
            if (bossHealth.BossHealthsliderThree.value >= 0)
            {
                currentStage = BossStage.StageThree;
            }
        }
        if (bossHealth.BossHealthsliderTwo.value <= 0 && bossHealth.BossHealthsliderOne.value <= 0)
        {
            if (bossHealth.BossHealthsliderThree.value <= 0 && bossHealth.BossHealthsliderFour.value >= 0)
            {
                currentStage = BossStage.StageFour;
            }
        }
    }
    //stoppingDistance 
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            bossHealth.SetEnemyHealth(20);
        }
        
    }
    void FixedUpdate()
    {
        if (currentStage == BossStage.StageOne)
        {
            PatternOne();
        }
        if (currentStage == BossStage.StageTwo)
        {
            if(count == 0)
            {
                PatternOne();
            }
            if(count == 1)
            {
                PatternTwo();
            }
            if (count >= 2)
            {
                count = 0;
            }
        }
        if (currentStage == BossStage.StageThree)
        {
            if (count == 0)
            {
                PatternOne();
            }
            if (count == 1)
            {
                PatternTwo();
            }
            if( count == 2)
            {
                PatternThree();
            }
            if (count == 3)
            {
                PatternThree();
            }
            if (count >= 4)
            {
                count = 0;
            }
        }
        if (currentStage == BossStage.StageThree)
        {
            
            if (count == 0)
            {
                fireSpeed = 1;
                PatternOne(); // faster

            }
            if (count == 1)
            {
                fireSpeed = 1f;
                PatternTwo();
            }
            if (count == 2)
            {
                fireSpeed = 1f;
                PatternThree();
            }
            if (count >= 3)
            {
                count = 0;
            }
        }
        if (currentStage == BossStage.StageFour)
        {
            fireSpeed = 1f;
            PatternThree();

            PatternFour();

            fireSpeed = 1f;
            if (count == 0)
            {
                PatternOne(); // faster

            }
            if (count == 1)
            {
                PatternTwo();
            }
            if (count >= 2)
            {
                count = 0;
            }
        }

    }
    void PatternOne()
    {

        if (TimeBetweenShots + fireSpeed <= Time.time)
        {
            //even
            EvenShooting();
            //uneven
            UnEvenShooting();
            //slight
            SlightShooting();
            TimeBetweenShots = Time.time;
        }

    }
    int counterOne;
    void PatternTwo()
    {
        if (counterOne <= 0)
        {
            EvenShooting();
            UnEvenShooting();
        }
        if (counterOne < 30)
        {
            counterOne++;
        }
        else if (counterOne >= 30)
        {
            SlightShooting();
            counterOne = 0;
            count++;
        }


    }
    bool hitTheEnd;
    int counter;
    void PatternThree()
    {
        //wave
        
        if (!hitTheEnd)
        {
            counter++;
        }
        if(hitTheEnd)
        {
            counter--;
        }
        
        if(counter <= 0 && hitTheEnd)
        {
            hitTheEnd = false;
            counter = 0;
            count++;
        }
        if (counter == 1)
        {
            Instantiate(projectile, centralFiringPoints[0].position, centralFiringPoints[0].rotation);
        }
        if (counter == 5)
        {
            Instantiate(projectile, SlightcentralFiringPoints[7].position, SlightcentralFiringPoints[7].rotation);
        }
        if (counter == 10)
        {
            Instantiate(projectile, UnevencentralFiringPoints[0].position, UnevencentralFiringPoints[0].rotation);
        }
        if (counter == 15)
        {
            Instantiate(projectile, SlightcentralFiringPoints[0].position, SlightcentralFiringPoints[0].rotation);
        }
        if (counter == 20)
        {
            Instantiate(projectile, centralFiringPoints[1].position, centralFiringPoints[1].rotation);
        }
        if (counter == 25)
        {
            Instantiate(projectile, SlightcentralFiringPoints[1].position, SlightcentralFiringPoints[1].rotation);
        }
        if (counter == 30)
        {
            Instantiate(projectile, UnevencentralFiringPoints[1].position, UnevencentralFiringPoints[1].rotation);
        }
        if (counter == 35)
        {
            Instantiate(projectile, SlightcentralFiringPoints[8].position, SlightcentralFiringPoints[8].rotation);
        }
        if (counter == 40)
        {
            Instantiate(projectile, centralFiringPoints[2].position, centralFiringPoints[2].rotation);
        }
        if (counter == 45)
        {
            Instantiate(projectile, SlightcentralFiringPoints[2].position, SlightcentralFiringPoints[2].rotation);
        }
        if (counter == 50)
        {
            Instantiate(projectile, UnevencentralFiringPoints[2].position, UnevencentralFiringPoints[2].rotation);
        }
        if (counter == 55)
        {
            Instantiate(projectile, SlightcentralFiringPoints[9].position, SlightcentralFiringPoints[9].rotation);
        }
        if (counter == 60)
        {
            Instantiate(projectile, centralFiringPoints[3].position, centralFiringPoints[3].rotation);
        }
        if (counter == 65)
        {
            Instantiate(projectile, SlightcentralFiringPoints[3].position, SlightcentralFiringPoints[3].rotation);
        }
        if (counter == 70)
        {
            Instantiate(projectile, UnevencentralFiringPoints[3].position, UnevencentralFiringPoints[3].rotation);
        }
        if (counter == 75)
        {
            Instantiate(projectile, SlightcentralFiringPoints[10].position, SlightcentralFiringPoints[10].rotation);
        }
        if (counter == 80)
        {
            Instantiate(projectile, centralFiringPoints[4].position, centralFiringPoints[4].rotation);
        }
        if (counter == 85)
        {
            Instantiate(projectile, SlightcentralFiringPoints[11].position, SlightcentralFiringPoints[11].rotation);
        }
        if (counter == 90)
        {
            Instantiate(projectile, UnevencentralFiringPoints[4].position, UnevencentralFiringPoints[4].rotation);
        }
        if (counter == 95)
        {
            Instantiate(projectile, SlightcentralFiringPoints[4].position, SlightcentralFiringPoints[4].rotation);
        }
        if (counter == 100)
        {
            Instantiate(projectile, centralFiringPoints[5].position, centralFiringPoints[5].rotation);
        }
        if (counter == 105)
        {
            Instantiate(projectile, SlightcentralFiringPoints[5].position, SlightcentralFiringPoints[5].rotation);
        }
        if (counter == 110)
        {
            Instantiate(projectile, UnevencentralFiringPoints[5].position, UnevencentralFiringPoints[5].rotation);
        }
        if (counter == 115)
        {
            Instantiate(projectile, SlightcentralFiringPoints[12].position, SlightcentralFiringPoints[12].rotation);
        }
        if (counter == 120)
        {
            Instantiate(projectile, centralFiringPoints[6].position, centralFiringPoints[6].rotation);
        }
        if (counter == 125)
        {
            Instantiate(projectile, SlightcentralFiringPoints[13].position, SlightcentralFiringPoints[13].rotation);
        }
        if (counter == 130)
        {
            Instantiate(projectile, UnevencentralFiringPoints[6].position, UnevencentralFiringPoints[6].rotation);
        }
        if (counter == 135)
        {
            Instantiate(projectile, SlightcentralFiringPoints[6].position, SlightcentralFiringPoints[6].rotation);
        }
        if (counter == 140)
        {
            Instantiate(projectile, centralFiringPoints[7].position, centralFiringPoints[7].rotation);
        }
        if (counter == 145)
        {
            Instantiate(projectile, SlightcentralFiringPoints[14].position, SlightcentralFiringPoints[14].rotation);
        }
        if (counter == 150)
        {
            Instantiate(projectile, UnevencentralFiringPoints[7].position, UnevencentralFiringPoints[7].rotation);
        }
        if (counter == 155)
        {
            Instantiate(projectile, SlightcentralFiringPoints[15].position, SlightcentralFiringPoints[15].rotation);
        }
        if (counter == 160)
        {
            hitTheEnd = true;
        }

    }
    int counterTwo = 160;
    bool hitTheEndTwo;
    void PatternFour()
    {
        //wave

        if (!hitTheEndTwo)
        {
            counterTwo--;
        }
        if(hitTheEndTwo)
        {
            counterTwo++;
        }
        if (counterTwo <= 0 )
        {
            hitTheEndTwo = true;
        }
        if (counterTwo == 1)
        {
            Instantiate(projectile, centralFiringPoints[0].position, centralFiringPoints[0].rotation);
        }
        if (counterTwo == 5)
        {
            Instantiate(projectile, SlightcentralFiringPoints[7].position, SlightcentralFiringPoints[7].rotation);
        }
        if (counterTwo == 10)
        {
            Instantiate(projectile, UnevencentralFiringPoints[0].position, UnevencentralFiringPoints[0].rotation);
        }
        if (counterTwo == 15)
        {
            Instantiate(projectile, SlightcentralFiringPoints[0].position, SlightcentralFiringPoints[0].rotation);
        }
        if (counterTwo == 20)
        {
            Instantiate(projectile, centralFiringPoints[1].position, centralFiringPoints[1].rotation);
        }
        if (counterTwo == 25)
        {
            Instantiate(projectile, SlightcentralFiringPoints[1].position, SlightcentralFiringPoints[1].rotation);
        }
        if (counterTwo == 30)
        {
            Instantiate(projectile, UnevencentralFiringPoints[1].position, UnevencentralFiringPoints[1].rotation);
        }
        if (counterTwo == 35)
        {
            Instantiate(projectile, SlightcentralFiringPoints[8].position, SlightcentralFiringPoints[8].rotation);
        }
        if (counterTwo == 40)
        {
            Instantiate(projectile, centralFiringPoints[2].position, centralFiringPoints[2].rotation);
        }
        if (counterTwo == 45)
        {
            Instantiate(projectile, SlightcentralFiringPoints[2].position, SlightcentralFiringPoints[2].rotation);
        }
        if (counterTwo == 50)
        {
            Instantiate(projectile, UnevencentralFiringPoints[2].position, UnevencentralFiringPoints[2].rotation);
        }
        if (counterTwo == 55)
        {
            Instantiate(projectile, SlightcentralFiringPoints[9].position, SlightcentralFiringPoints[9].rotation);
        }
        if (counterTwo == 60)
        {
            Instantiate(projectile, centralFiringPoints[3].position, centralFiringPoints[3].rotation);
        }
        if (counterTwo == 65)
        {
            Instantiate(projectile, SlightcentralFiringPoints[3].position, SlightcentralFiringPoints[3].rotation);
        }
        if (counterTwo == 70)
        {
            Instantiate(projectile, UnevencentralFiringPoints[3].position, UnevencentralFiringPoints[3].rotation);
        }
        if (counterTwo == 75)
        {
            Instantiate(projectile, SlightcentralFiringPoints[10].position, SlightcentralFiringPoints[10].rotation);
        }
        if (counterTwo == 80)
        {
            Instantiate(projectile, centralFiringPoints[4].position, centralFiringPoints[4].rotation);
        }
        if (counterTwo == 85)
        {
            Instantiate(projectile, SlightcentralFiringPoints[11].position, SlightcentralFiringPoints[11].rotation);
        }
        if (counterTwo == 90)
        {
            Instantiate(projectile, UnevencentralFiringPoints[4].position, UnevencentralFiringPoints[4].rotation);
        }
        if (counterTwo == 95)
        {
            Instantiate(projectile, SlightcentralFiringPoints[4].position, SlightcentralFiringPoints[4].rotation);
        }
        if (counterTwo == 100)
        {
            Instantiate(projectile, centralFiringPoints[5].position, centralFiringPoints[5].rotation);
        }
        if (counterTwo == 105)
        {
            Instantiate(projectile, SlightcentralFiringPoints[5].position, SlightcentralFiringPoints[5].rotation);
        }
        if (counterTwo == 110)
        {
            Instantiate(projectile, UnevencentralFiringPoints[5].position, UnevencentralFiringPoints[5].rotation);
        }
        if (counterTwo == 115)
        {
            Instantiate(projectile, SlightcentralFiringPoints[12].position, SlightcentralFiringPoints[12].rotation);
        }
        if (counterTwo == 120)
        {
            Instantiate(projectile, centralFiringPoints[6].position, centralFiringPoints[6].rotation);
        }
        if (counterTwo == 125)
        {
            Instantiate(projectile, SlightcentralFiringPoints[13].position, SlightcentralFiringPoints[13].rotation);
        }
        if (counterTwo == 130)
        {
            Instantiate(projectile, UnevencentralFiringPoints[6].position, UnevencentralFiringPoints[6].rotation);
        }
        if (counterTwo == 135)
        {
            Instantiate(projectile, SlightcentralFiringPoints[6].position, SlightcentralFiringPoints[6].rotation);
        }
        if (counterTwo == 140)
        {
            Instantiate(projectile, centralFiringPoints[7].position, centralFiringPoints[7].rotation);
        }
        if (counterTwo == 145)
        {
            Instantiate(projectile, SlightcentralFiringPoints[14].position, SlightcentralFiringPoints[14].rotation);
        }
        if (counterTwo == 150)
        {
            Instantiate(projectile, UnevencentralFiringPoints[7].position, UnevencentralFiringPoints[7].rotation);
        }
        if (counterTwo == 155)
        {
            Instantiate(projectile, SlightcentralFiringPoints[15].position, SlightcentralFiringPoints[15].rotation);
        }
        if (counterTwo >= 160 && hitTheEndTwo)
        {
            counterTwo = 160;
            hitTheEndTwo = false;
        }

    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }




























    void WaveThingy()
        {
            // Instantiate(projectile, centralFiringPoints[0].position, centralFiringPoints[0].rotation);
            //
            // Instantiate(projectile, SlightcentralFiringPoints[7].position, SlightcentralFiringPoints[7].rotation);
            //
            // Instantiate(projectile, UnevencentralFiringPoints[0].position, UnevencentralFiringPoints[0].rotation);
            //
            //Instantiate(projectile, SlightcentralFiringPoints[0].position, SlightcentralFiringPoints[0].rotation);
            //
            //Instantiate(projectile, centralFiringPoints[1].position, centralFiringPoints[1].rotation);
            //
            //Instantiate(projectile, SlightcentralFiringPoints[1].position, SlightcentralFiringPoints[1].rotation);
            //
            //Instantiate(projectile, UnevencentralFiringPoints[1].position, UnevencentralFiringPoints[1].rotation);
            //
            //Instantiate(projectile, SlightcentralFiringPoints[8].position, SlightcentralFiringPoints[8].rotation);
            //  
            //Instantiate(projectile, centralFiringPoints[2].position, centralFiringPoints[2].rotation);
            //
            //Instantiate(projectile, SlightcentralFiringPoints[2].position, SlightcentralFiringPoints[2].rotation);
            //
            //Instantiate(projectile, UnevencentralFiringPoints[2].position, UnevencentralFiringPoints[2].rotation);
            //
            //Instantiate(projectile, SlightcentralFiringPoints[9].position, SlightcentralFiringPoints[9].rotation);
            //
            //Instantiate(projectile, centralFiringPoints[3].position, centralFiringPoints[3].rotation);
            //
            //Instantiate(projectile, SlightcentralFiringPoints[3].position, SlightcentralFiringPoints[3].rotation);
            //
            //Instantiate(projectile, UnevencentralFiringPoints[3].position, UnevencentralFiringPoints[3].rotation);
            //
            //Instantiate(projectile, SlightcentralFiringPoints[10].position, SlightcentralFiringPoints[10].rotation);
            //
            //Instantiate(projectile, centralFiringPoints[4].position, centralFiringPoints[4].rotation);
            //
            //Instantiate(projectile, SlightcentralFiringPoints[11].position, SlightcentralFiringPoints[11].rotation);
            //
            //Instantiate(projectile, UnevencentralFiringPoints[4].position, UnevencentralFiringPoints[4].rotation);
            //
            //Instantiate(projectile, SlightcentralFiringPoints[4].position, SlightcentralFiringPoints[4].rotation);
            //
            //Instantiate(projectile, centralFiringPoints[5].position, centralFiringPoints[5].rotation);
            //
            //Instantiate(projectile, SlightcentralFiringPoints[5].position, SlightcentralFiringPoints[5].rotation);
            //
            //Instantiate(projectile, UnevencentralFiringPoints[5].position, UnevencentralFiringPoints[5].rotation);
            //
            //Instantiate(projectile, SlightcentralFiringPoints[12].position, SlightcentralFiringPoints[12].rotation);
            //
            //Instantiate(projectile, centralFiringPoints[6].position, centralFiringPoints[6].rotation);
            //
            //Instantiate(projectile, SlightcentralFiringPoints[13].position, SlightcentralFiringPoints[13].rotation);
            //
            //Instantiate(projectile, UnevencentralFiringPoints[6].position, UnevencentralFiringPoints[6].rotation);
            ////
            //Instantiate(projectile, SlightcentralFiringPoints[6].position, SlightcentralFiringPoints[6].rotation);
            //
            //Instantiate(projectile, centralFiringPoints[7].position, centralFiringPoints[7].rotation);
            //
            //Instantiate(projectile, SlightcentralFiringPoints[14].position, SlightcentralFiringPoints[14].rotation);
            //
            //Instantiate(projectile, UnevencentralFiringPoints[7].position, UnevencentralFiringPoints[7].rotation);
            //
            //Instantiate(projectile, SlightcentralFiringPoints[15].position, SlightcentralFiringPoints[15].rotation);
        }
    private void EvenShooting()
    {
        Instantiate(projectile, centralFiringPoints[0].position, centralFiringPoints[0].rotation);
        Instantiate(projectile, centralFiringPoints[1].position, centralFiringPoints[1].rotation);
        Instantiate(projectile, centralFiringPoints[2].position, centralFiringPoints[2].rotation);
        Instantiate(projectile, centralFiringPoints[3].position, centralFiringPoints[3].rotation);
        Instantiate(projectile, centralFiringPoints[4].position, centralFiringPoints[4].rotation);
        Instantiate(projectile, centralFiringPoints[5].position, centralFiringPoints[5].rotation);
        Instantiate(projectile, centralFiringPoints[6].position, centralFiringPoints[6].rotation);
        Instantiate(projectile, centralFiringPoints[7].position, centralFiringPoints[7].rotation);
    }
    private void UnEvenShooting()
    {
        Instantiate(projectile, UnevencentralFiringPoints[0].position, UnevencentralFiringPoints[0].rotation);
        Instantiate(projectile, UnevencentralFiringPoints[1].position, UnevencentralFiringPoints[1].rotation);
        Instantiate(projectile, UnevencentralFiringPoints[2].position, UnevencentralFiringPoints[2].rotation);
        Instantiate(projectile, UnevencentralFiringPoints[3].position, UnevencentralFiringPoints[3].rotation);
        Instantiate(projectile, UnevencentralFiringPoints[4].position, UnevencentralFiringPoints[4].rotation);
        Instantiate(projectile, UnevencentralFiringPoints[5].position, UnevencentralFiringPoints[5].rotation);
        Instantiate(projectile, UnevencentralFiringPoints[6].position, UnevencentralFiringPoints[6].rotation);
        Instantiate(projectile, UnevencentralFiringPoints[7].position, UnevencentralFiringPoints[7].rotation);
    }
    private void SlightShooting()
    {
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
    }
}
