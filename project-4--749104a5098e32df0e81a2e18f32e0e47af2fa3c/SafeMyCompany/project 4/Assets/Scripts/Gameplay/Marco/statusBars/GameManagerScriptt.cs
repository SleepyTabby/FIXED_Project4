using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScriptt : MonoBehaviour
{
    void Start()
    {

    }
    public void GameOver()
    {
        PlayerStatistics.timesDeath++;
        SceneManager.LoadScene(2);
    }
}
