using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGunPressurePlate : MonoBehaviour
{
    public MiniGun miniGun;
    private void OnCollisionEnter(Collision col)
    {
        miniGun.pressurePlate = true;
    }
}
