using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectricAmmoBar : MonoBehaviour
{
    public Slider Ammoslider;

    public void SetMaxAmmo(float maxAmmo)
    {
        Ammoslider.maxValue = maxAmmo;
        Ammoslider.value = maxAmmo;
    }
    public void SetAmmo(float ammo)
    {
        Ammoslider.value = ammo;
    }
}
