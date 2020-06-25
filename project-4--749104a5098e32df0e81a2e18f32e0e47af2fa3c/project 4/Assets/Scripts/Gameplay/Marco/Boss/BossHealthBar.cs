using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    public Slider BossHealthsliderTwo;
    public Slider BossHealthsliderOne;
    public Slider BossHealthsliderThree;
    public Slider BossHealthsliderFour;
    public int[] HealthBar;
    private void Start()
    {
        SetEnemyMaxHealth(HealthBar[0]);
        SetEnemyMaxHealthOne(HealthBar[1]);
        SetEnemyMaxHealthTwo(HealthBar[2]);
        SetEnemyMaxHealthThree(HealthBar[3]);
    }

    public void SetEnemyMaxHealth(int health)
    {
        BossHealthsliderOne.maxValue = health;
        BossHealthsliderOne.value = health;
    }
    public void SetEnemyMaxHealthOne(int health)
    {
        BossHealthsliderTwo.maxValue = health;
        BossHealthsliderTwo.value = health;
    }
    public void SetEnemyMaxHealthTwo(int health)
    {
        BossHealthsliderThree.maxValue = health;
        BossHealthsliderThree.value = health;
    }
    public void SetEnemyMaxHealthThree(int health)
    {
        BossHealthsliderFour.maxValue = health;
        BossHealthsliderFour.value = health;
    }
    
    public void SetEnemyHealth(int health)
    {
        if(BossHealthsliderOne.value >= 0)
        {
            BossHealthsliderOne.value -= health;
        }
        if (BossHealthsliderTwo.value >= 0 && BossHealthsliderOne.value <= 0)
        {
            BossHealthsliderTwo.value -= health;
        }
        if (BossHealthsliderTwo.value <= 0 && BossHealthsliderOne.value <= 0)
        {
            if(BossHealthsliderThree.value >= 0)
            {
                BossHealthsliderThree.value -= health;
            }
        }
        if (BossHealthsliderTwo.value <= 0 && BossHealthsliderOne.value <= 0)
        {
            if (BossHealthsliderThree.value <= 0 && BossHealthsliderFour.value >= 0)
            {
                BossHealthsliderFour.value -= health;
            }       
        }
    }
}
