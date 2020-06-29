using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKeyCard : MonoBehaviour
{
    public ItemPickup pickup;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (gameObject.CompareTag("Blue"))
            {
                pickup.BlueKey = true;
                
                gameObject.SetActive(false);
            }
        }
    }
}
