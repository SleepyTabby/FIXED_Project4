using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transporter : MonoBehaviour
{
    void OnTriggerEnter (Collider col)
    {
        SceneManager.LoadScene(+1);
    }
}
