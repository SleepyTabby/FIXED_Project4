using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class dropGun : MonoBehaviour
{
    [SerializeField] GameObject gun;
    [SerializeField] GameObject gunFloor;
    [SerializeField] GameObject Fullgun;
    [SerializeField] Transform gunPos;

    public Transform playerPos;

    public bool dropallow = true;
    void Update()
    {
        //Vector3 posmore = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        if (Input.GetKeyDown(KeyCode.G) && dropallow == true)
        {
            gunFloor.SetActive(true);
            Fullgun.SetActive(true);
            Instantiate(gunFloor, (transform.position + (transform.forward * 2)), Quaternion.identity);
            gun.SetActive(false);
            Fullgun.SetActive(false);
            gunFloor.SetActive(false);
            dropallow = false;
            //Destroy(gun);
        }
    }
}
