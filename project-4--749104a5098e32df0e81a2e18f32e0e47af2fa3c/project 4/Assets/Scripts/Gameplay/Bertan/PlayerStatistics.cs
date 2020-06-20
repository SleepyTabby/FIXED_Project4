using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{
    public int AmountOfBullets;
    public int AmountOfBulletsHit;


    public int Kills;
    public int enemiesLeft;
    public static int timesDeath;

    public float Accuracy()
    {


        if (AmountOfBullets == 0 && AmountOfBulletsHit == 0)
        {
            return 100f;
        }
        else
        {
            return (float)AmountOfBulletsHit / (float)AmountOfBullets * 100;
        }
    }
    //static public void EnemiesLeft()
    //{

    //}
    void Start()
    {

    }
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;

        //if (gameObject.CompareTag("Enemy"))
        //{
        //    EnemiesLeft
        //}
    }


}
