using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoPool : MonoBehaviour
{
    public Slider magslider;

    public void SetMaxMag(float maxMag)
    {
        magslider.maxValue = maxMag;
        magslider.value = maxMag;
    }
    public void SetMag(float mag)
    {
        magslider.value = mag;
    }
}
