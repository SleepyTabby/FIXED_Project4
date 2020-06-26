using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("OgLevel");
        Time.timeScale = 1f;
        Debug.Log("Loaded scene 1 - Game Scene");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
