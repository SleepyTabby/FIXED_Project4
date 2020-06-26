using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lift : MonoBehaviour
{
    float timer = 5f;
    void Start()
    {
        
    }
    void Update()
    {
        timer -= Time.deltaTime;

        if (Time.deltaTime <= 0)
        {
            SceneManager.LoadScene(+1);
        }
    }
}
