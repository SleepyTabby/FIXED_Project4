using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccuracyDisplay : MonoBehaviour
{
    public Text text;
    public PlayerStatistics playerStatistics;
    void Start()
    {
        playerStatistics = FindObjectOfType<PlayerStatistics>();
    }

    void Update()
    {
        text.text = "Accuracy: " + Mathf.Round(playerStatistics.Accuracy()).ToString();
    }
}
