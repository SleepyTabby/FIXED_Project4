using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPack : MonoBehaviour
{
    public Gun GiveAmmo;
    [SerializeField] private float AmmoGainedByPickingUpAmmoPack = 10f;
    
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" )
        {
            GiveAmmo.totalAmmo += 20;
            Destroy(this.gameObject);
        }
    }
}

