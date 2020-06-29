using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevelScript : MonoBehaviour
{
    public Slider countDownSlider;
    public LevelLoader loader;
    void FixedUpdate()
    {
        countDownSlider.value--;
    }
    void Update()
    {
        if (countDownSlider.value <= 0)
        {
            loader.LoadNextLevel();
        }
    }
}
