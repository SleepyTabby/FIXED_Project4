using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBullet : MonoBehaviour
{
    public HealthBarScript DealDamage;

    public ArmorBar CheckArmorDMG;

    public EnemyProjectile enemy;

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "BulletFromEnemy")
        {
            if (CheckArmorDMG.RemainingArmor >= 1)
            {
                CheckArmorDMG.LoseArmor(20); 
            }
            
            if (CheckArmorDMG.RemainingArmor <= 0)
            {
                DealDamage.LoseHealth(20);
            }
            
        }
    }
}
