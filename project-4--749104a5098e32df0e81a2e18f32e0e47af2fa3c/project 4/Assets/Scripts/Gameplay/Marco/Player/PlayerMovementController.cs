using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    Rigidbody rigidBody;

    public KeyBindScript kbs;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        PlayerController();
        RotatePlayer();
       
        
    }

    void PlayerController()
    {
        rigidBody.freezeRotation = true;
        //float hor = Input.GetAxis("Horizontal");
        //float ver = Input.GetAxis("Vertical");

        float ver = 0;
        float hor = 0;

        if (Input.GetKey(kbs.keys["Up"]))
        {
            //ver = Input.GetAxis("Vertical");
            ver = 1;
        }
        if (Input.GetKey(kbs.keys["Left"]))
        {
            //hor = Input.GetAxis("Horizontal");
            hor = -1;
        }
        if (Input.GetKey(kbs.keys["Down"]))
        {
            //ver = Input.GetAxis("Vertical");
            ver = -1;
        }
        if (Input.GetKey(kbs.keys["Right"]))
        {
            //hor = Input.GetAxis("Horizontal");
            hor = 1;
        }

        Vector3 PlayerMovement = new Vector3(hor, 0f, ver);

        //transform.Translate(PlayerMovement, Space.Self);
        rigidBody.MovePosition(rigidBody.position + PlayerMovement * speed * Time.deltaTime);
    }
    void RotatePlayer()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }

    }
}

