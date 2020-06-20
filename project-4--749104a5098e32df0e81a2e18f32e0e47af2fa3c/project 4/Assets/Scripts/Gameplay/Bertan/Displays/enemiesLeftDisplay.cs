using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemiesLeftDisplay : MonoBehaviour
{
    public Text text;
    public PlayerStatistics playerStatistics;

    void Start()
    {
        playerStatistics = FindObjectOfType<PlayerStatistics>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Enemies left: " + FindObjectOfType<PlayerStatistics>().enemiesLeft;
    }

}
