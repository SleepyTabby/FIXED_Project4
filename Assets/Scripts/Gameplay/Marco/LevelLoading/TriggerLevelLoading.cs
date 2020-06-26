using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLevelLoading : MonoBehaviour
{
    public LevelLoader LevelLoader;
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            LevelLoader.LoadNextLevel();
        }
    }
}
