using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame

    public void StartGame()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
        Debug.Log("Loaded scene 1 - Game Scene");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
