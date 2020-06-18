using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{
    public int AmountOfBullets;
    public int AmountOfBulletsHit;

    public int Kills;

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
    void Start()
    {

    }
    void Update()
    {

    }

}
