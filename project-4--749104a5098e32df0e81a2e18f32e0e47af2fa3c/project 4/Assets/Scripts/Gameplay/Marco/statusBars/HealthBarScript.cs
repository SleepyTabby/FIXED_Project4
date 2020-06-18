using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider Healthslider;
    public GameManagerScript gameOver;

    void Update()
    {
        if (Healthslider.value <= 0)
        {
            gameOver.GameOver();
        }
    }

    public void SetMaxHealth(int health)
    {
        Healthslider.maxValue = health;
        Healthslider.value = health;
    }
    public void SetHealth(int health)
    {
        Healthslider.value = health;
    }
    public void GainHealth(int health)
    {
        Healthslider.value += health;
    }
    public void LoseHealth(int health)
    {
        Healthslider.value -= health;
    }
}
