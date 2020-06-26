using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGunShootingScript : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            MiniGun.Instance.Shoot();
        }
    }
}
