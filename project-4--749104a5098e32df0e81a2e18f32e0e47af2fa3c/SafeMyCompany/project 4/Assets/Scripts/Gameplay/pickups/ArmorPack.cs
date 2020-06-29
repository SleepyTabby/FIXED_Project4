using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPack : MonoBehaviour
{
    public ArmorBar GetArmor;
    [SerializeField] private int ArmorGainedByPickingUpArmorPack = 25;

    void OnTriggerEnter(Collider col)
    {
        GetArmor.GainArmor(ArmorGainedByPickingUpArmorPack);
        Destroy(this.gameObject);
    }
}
