﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupGun : MonoBehaviour
{
    [SerializeField] public GameObject gun;
    [SerializeField] public GameObject gunFloor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider collider)
    {
        gun.SetActive(true);
        gunFloor.SetActive(false);
        print("pick up gun");

    }
}