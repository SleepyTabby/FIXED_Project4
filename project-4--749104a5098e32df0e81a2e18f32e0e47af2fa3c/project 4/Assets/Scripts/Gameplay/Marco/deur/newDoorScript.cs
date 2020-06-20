using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newDoorScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float desiredAngle;
    [SerializeField] float neutralAngle;
    float angle;
    [SerializeField] Vector3 direction;
    private bool openDoor = true;
    private bool clickedMouse;
    private float countdown;
    private bool startCountDown;

    void Start()
    {
        angle = transform.eulerAngles.y;
        //if (transform.rotation.y == 0)
        //{
        //    desiredAngle = 270;
        //    neutralAngle = 0;
        //}
        //else if (transform.rotation.y == 90)
        //{
        //    desiredAngle = 0;
        //    neutralAngle = 90;
        //}
    }
    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.tag == "Player")
    //    {
    //        openDoor = !openDoor;
    //    }
    //}


   void Update()
    {
        //if (Input.GetKey(KeyCode.E))
        //{
        //    clickedMouse = true;
        //    startCountDown = true;
        //}
    }

    //void OnMouseDown()
    //{
    //    clickedMouse = true;
    //    startCountDown = true;
    //}
    //void OnMouseUp()
    //{
    //    clickedMouse = false;
    //    countdown = 0;
    //    startCountDown = false;
    //}
    void OnMouseDown()
    {
        openDoor = !openDoor;
    }
    void FixedUpdate()
    {
        if (startCountDown)
        {
            countdown++;
            if (countdown >= 20)
            {
                clickedMouse = false;
                countdown = 0;
                startCountDown = false;
            }
        }
        if(Mathf.Round(transform.eulerAngles.y) != angle)
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
