using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowmotion : MonoBehaviour
{
    public float cooldown;
    public float cooldownfornormal;
    void Start()
    {
        //cooldown = 60;
    }

    void Update()
    {
        cooldown -= Time.deltaTime;

        cooldownfornormal -= Time.deltaTime;


        if (Input.GetKey(KeyCode.Mouse2) && cooldown <= 0)
        {
            Time.timeScale = 0.5f;
            cooldown = 60;
            cooldownfornormal = 30;
        }
        if (cooldownfornormal <= 0 && cooldown >= 0.01f)
        {
            Time.timeScale = 1f;
        }
    }
}
