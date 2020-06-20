using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFriendlyBullet : MonoBehaviour
{
    public EnemyController DealDamage;
    public Projectile Bullet;
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Bullet")
        {
            DealDamage.LoseSomeHealth(20);
            DealDamage.state = EnemyState.gettingShot;
        }
        if (col.gameObject.tag == "FireBullet")
        {
            DealDamage.LoseSomeHealth(15);
            //add burn dmg met enum
            DealDamage.state = EnemyState.gettingShot;
        }
        if (col.gameObject.tag == "ElectricBullet")
        {
            DealDamage.LoseSomeHealth(40);
            //add stun met enum
            DealDamage.state = EnemyState.gettingShot;
        }
    }
}
