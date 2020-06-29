using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lift1 : MonoBehaviour
{
    public float timer;
    void Start()
    {
        timer = 4.5f;   
    }
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SceneManager.LoadScene("FinalLevel");
        }
    }
}
