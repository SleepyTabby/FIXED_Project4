using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;
    [SerializeField] GameObject NightVision;

    private void Update()
    {

    }
    void LateUpdate()
    {
        Vector3 EndPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, EndPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
