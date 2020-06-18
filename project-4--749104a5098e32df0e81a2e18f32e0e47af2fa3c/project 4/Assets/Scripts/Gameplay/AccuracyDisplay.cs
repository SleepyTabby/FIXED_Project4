using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccuracyDisplay : MonoBehaviour
{
    public Text text;
    public PlayerStatistics playerStatistics;
    // Start is called before the first frame update
    void Start()
    {
        playerStatistics = FindObjectOfType<PlayerStatistics>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Accuracy: " + Mathf.Round(playerStatistics.Accuracy()).ToString();
    }
}
