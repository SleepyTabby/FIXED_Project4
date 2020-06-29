using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFriendlyBullet : MonoBehaviour
{
    public EnemyController DealDamage;
    public EnemyHealthBar enemyHealth;
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "MiniGunBullet")
        {
            DealDamage.Enemyhealth -= 35;
            enemyHealth.SetEnemyHealth(DealDamage.Enemyhealth);
        }
        if (col.gameObject.tag == "Bullet")
        {
            DealDamage.Enemyhealth -= 20;
            DealDamage.state = EnemyState.gettingShot;
            enemyHealth.SetEnemyHealth(DealDamage.Enemyhealth);
            FindObjectOfType<PlayerStatistics>().AmountOfBulletsHit++;
        }
        if (col.gameObject.tag == "FireBullet")
        {
            //add burn dmg met enum
            DealDamage.Enemyhealth -= 15;
            DealDamage.state = EnemyState.gettingShot;
            enemyHealth.SetEnemyHealth(DealDamage.Enemyhealth);
            FindObjectOfType<PlayerStatistics>().AmountOfBulletsHit++;
        }
        if (col.gameObject.tag == "ElectricBullet")
        {
            //add stun met enum
            DealDamage.Enemyhealth -= 40;
            DealDamage.state = EnemyState.gettingShot;
            enemyHealth.SetEnemyHealth(DealDamage.Enemyhealth);
            FindObjectOfType<PlayerStatistics>().AmountOfBulletsHit++;
        }
    }
}
