using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorBar : MonoBehaviour
{
    public Slider Armorslider;
    public float RemainingArmor = 50;

    void Start()
    {
        SetMaxArmor(50);
    }

    void Update()
    {
        RemainingArmor = Armorslider.value;
    }
    
    public void SetMaxArmor(int Armor)
    {
        Armorslider.maxValue = Armor;
    }
    public void SetArmor(int Armor)
    {
        Armorslider.value = Armor;
    }
    public void GainArmor(int Armor)
    {
        Armorslider.value += Armor;
    }
    public void LoseArmor(int Armor)
    {
        Armorslider.value -= Armor;
    }
    
}
