﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float maxAngle;
    [SerializeField] float maxRadius;
    [SerializeField] float detectionRadius;
    public EnemyController controller;
    public Boss boss;
    bool IsInFov;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Vector3 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * maxRadius;
        Vector3 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward * maxRadius;

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);

        if (!IsInFov)
        {
            Gizmos.color = Color.black;
        }
        else
        {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawRay(transform.position, (target.position - transform.position).normalized * maxRadius) ;

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * maxRadius);
    }

    public bool InFieldOfView(Transform checkingObject, Transform target, float maxAngle, float maxRadius)
    {
        Collider[] overlaps = new Collider[50];
        int count = Physics.OverlapSphereNonAlloc(checkingObject.position, maxRadius, overlaps);
        for (int i = 0; i < count + 1; i++)
        {
            if (overlaps[i] != null)
            {
                if(overlaps[i].transform == target)
                {
                    Vector3 directionBetween = (target.position - checkingObject.position).normalized;

                    directionBetween.y *= 0;

                    float angle = Vector3.Angle(checkingObject.forward, directionBetween);

                    if (angle <= maxAngle)
                    {
                        Ray ray = new Ray(checkingObject.position, target.position- checkingObject.position);
                        RaycastHit hit;
                        if(Physics.Raycast(ray, out hit, maxRadius))
                        {
                            if(hit.transform == target)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
        }
        return false;
    }
    void Update()
    {
        IsInFov = InFieldOfView(transform,target, maxAngle, maxRadius);

        if (IsInFov && tag == "Enemy")
        {
            controller.state = EnemyState.attacking;
        }
        if (IsInFov && tag == "Boss" && boss.currentStage == BossStage.Waiting)
        {
            boss.currentStage = BossStage.detectedPlayer;
        }

    }
    
}
