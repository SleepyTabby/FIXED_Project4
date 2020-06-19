using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    [SerializeField] private float rotatingSpeed;

    void Update()
    {
        transform.Rotate(0, rotatingSpeed, 0);
    }
}
