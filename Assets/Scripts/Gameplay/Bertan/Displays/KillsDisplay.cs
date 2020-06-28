using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillsDisplay : MonoBehaviour
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
        text.text = "Kills: " + FindObjectOfType<PlayerStatistics>().Kills;
        
        /*Mathf.Round(playerStatistics.Kills()).ToString();*/
    }
}