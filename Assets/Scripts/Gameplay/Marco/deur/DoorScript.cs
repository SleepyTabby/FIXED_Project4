using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private bool doorOpened;
    private bool coroutineAllowed;
    [SerializeField] private float deurNeutraal = 90f;
    [SerializeField] private float deurOpen = 90f;
    void Start()
    {
        doorOpened = false;
        coroutineAllowed = true;
    }

    private void OnMouseDown()
    {
        Invoke("RunCoroutine", 0f);
    }

    private void RunCoroutine()
    {
        StartCoroutine("OpenThatDoor");
    }
    private  IEnumerator OpenThatDoor()
    {
        coroutineAllowed = false;
        if (!doorOpened)
        {
            for (float i = 0f; i < deurNeutraal; i += 3f)
            {
                transform.localRotation = Quaternion.Euler(0f, i, 0f);
                yield return new WaitForSeconds(0f);
            }
            doorOpened = true;
        }
        else
        {
            for (float i = deurOpen; i > 0f; i -= 3f)
            {

                transform.localRotation = Quaternion.Euler(0f, i, 0f);
                yield return new WaitForSeconds(0f);
            }
            doorOpened = false;
        }
        coroutineAllowed = true;
    }
    
   
}
