using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider Healthslider;
    public GameManagerScript gameOver;

    float timer = 3;
    public float countdown;

    void Start()
    {
        countdown = timer;
    }
    void Update()
    {
        
        if (Healthslider.value <= 0)
        {
            countdown -= Time.deltaTime;
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
