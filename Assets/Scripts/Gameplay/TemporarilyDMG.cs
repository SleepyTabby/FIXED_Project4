using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporarilyDMG : MonoBehaviour
{
    public HealthBarScript DealDamage;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player") 
        {
            DealDamage.LoseHealth(20);
            Destroy(this.gameObject);
        }
    }
}

