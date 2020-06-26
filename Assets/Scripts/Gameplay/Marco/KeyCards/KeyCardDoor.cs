using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardDoor : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float desiredAngle;
    [SerializeField] float neutralAngle;
    [SerializeField] float angle;
    [SerializeField] Vector3 direction;
    public bool openDoor = true;

    public KeycardChecker keycard;
    void Start()
    {
        angle = transform.eulerAngles.y;
    }
    


   
    void OnMouseDown()
    {
        openDoor = !openDoor;
    }
    void FixedUpdate()
    {
       if(tag == "Red" && keycard.RedKey)
        {
            if (Mathf.Round(transform.eulerAngles.y) != angle)
            {
                transform.Rotate(direction * speed);
            }
            if (openDoor) // && clickedMouse
            {
                angle = neutralAngle;
                direction = Vector3.up;
            }
            else
            {
                openDoor = false;
            }
            if (!openDoor) //&& clickedMouse
            {
                angle = desiredAngle;
                direction = -Vector3.up;
            }
            else
            {
                openDoor = true;
            }
        }
       if(tag == "Green" && keycard.GreenKey)
        {
            if (Mathf.Round(transform.eulerAngles.y) != angle)
            {
                transform.Rotate(direction * speed);
            }
            if (openDoor) // && clickedMouse
            {
                angle = neutralAngle;
                direction = Vector3.up;
            }
            else
            {
                openDoor = false;
            }
            if (!openDoor) //&& clickedMouse
            {
                angle = desiredAngle;
                direction = -Vector3.up;
            }
            else
            {
                openDoor = true;
            }
        }
       if(tag == "Blue" && keycard.BlueKey)
        {
            if (Mathf.Round(transform.eulerAngles.y) != angle)
            {
                transform.Rotate(direction * speed);
            }
            if (openDoor) // && clickedMouse
            {
                angle = neutralAngle;
                direction = Vector3.up;
            }
            else
            {
                openDoor = false;
            }
            if (!openDoor) //&& clickedMouse
            {
                angle = desiredAngle;
                direction = -Vector3.up;
            }
            else
            {
                openDoor = true;
            }
        }
       if(tag == "Pink" && keycard.PinkKey)
        {
            if (Mathf.Round(transform.eulerAngles.y) != angle)
            {
                transform.Rotate(direction * speed);
            }
            if (openDoor) // && clickedMouse
            {
                angle = neutralAngle;
                direction = Vector3.up;
            }
            else
            {
                openDoor = false;
            }
            if (!openDoor) //&& clickedMouse
            {
                angle = desiredAngle;
                direction = -Vector3.up;
            }
            else
            {
                openDoor = true;
            }
        }
    }
}
