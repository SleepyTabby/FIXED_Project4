using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKeyCard : MonoBehaviour
{
    public ItemPickup pickup;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (gameObject.CompareTag("Red"))
            {
                pickup.RedKey = true;
                
                gameObject.SetActive(false);
            }
        }
    }
}
