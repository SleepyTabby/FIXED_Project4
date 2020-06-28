using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemies : MonoBehaviour
{
    float counter;
    [SerializeField] GameObject enemy;
    public EnemyController controller;
    void FixedUpdate()
    {
        if ( counter >= 100)
        {
            Instantiate(enemy, this.transform);
            controller.state = EnemyState.attacking;
            counter = 0;
        }
        if (counter < 100)
        {
            counter++;
        }
    }
}
