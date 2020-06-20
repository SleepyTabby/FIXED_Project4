using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenKeyCard : MonoBehaviour
{
    public ItemPickup pickup;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (gameObject.CompareTag("Green"))
            {
                pickup.GreenKey = true;
                
                gameObject.SetActive(false);
            }
        }
    }
}
