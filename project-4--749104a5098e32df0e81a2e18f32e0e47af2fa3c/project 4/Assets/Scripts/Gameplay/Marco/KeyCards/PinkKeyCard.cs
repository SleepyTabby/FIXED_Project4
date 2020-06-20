using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkKeyCard : MonoBehaviour
{
    public ItemPickup pickup;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (gameObject.CompareTag("Pink"))
            {
                pickup.PinkKey = true;
                
                gameObject.SetActive(false);
            }
        }
    }
}

