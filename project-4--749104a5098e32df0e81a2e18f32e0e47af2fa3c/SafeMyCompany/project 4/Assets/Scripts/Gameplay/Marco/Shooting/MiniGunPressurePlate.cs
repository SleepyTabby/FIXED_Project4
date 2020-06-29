using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGunPressurePlate : MonoBehaviour
{
    public MiniGun miniGun;
    [SerializeField] GameObject endCounter;
    [SerializeField] GameObject enemySpawning;
    [SerializeField] private CameraFollow camera;
    [SerializeField] bool MakeItTrue;
    private void OnCollisionEnter(Collision col)
    {

        if(col.gameObject.tag == "Player")
        {
            enemySpawning.SetActive(true);
            endCounter.SetActive(true);
            miniGun.pressurePlate = MakeItTrue;
            if (!MakeItTrue)
            {
                camera.offset = new Vector3(0, 7, 0);
            }
        }
    }

}
