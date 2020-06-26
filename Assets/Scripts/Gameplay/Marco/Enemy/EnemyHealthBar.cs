using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider EnemyHealthslider;

    private void Update()
    {
        if(EnemyHealthslider.value <= 0)
        {
            FindObjectOfType<PlayerStatistics>().Kills++;
        }
    }
    public void SetEnemyMaxHealth(int health)
    {
        EnemyHealthslider.maxValue = health;
        EnemyHealthslider.value = health;
    }

    public void SetEnemyHealth(int health)
    {
        EnemyHealthslider.value = health;
    }

    public void ReduceEnemyHealth(int health)
    {
        EnemyHealthslider.value -= health;
    }
}
