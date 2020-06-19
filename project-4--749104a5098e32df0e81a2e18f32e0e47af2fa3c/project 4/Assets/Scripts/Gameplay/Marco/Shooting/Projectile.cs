using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 firingPoint;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float MaxDistance;
    private string currentGun = "handGun";
    public static float currentDamage = 0f;
    [Header("Acceleration")]
    [Range(0, 1)]
    [SerializeField] float fireBulletAccelerationFigures;
    float fireSpeed;
    [Range(0, 1)]
    [SerializeField] float electricBulletAccelerationFigures;
    float electricSpeed;

    void Start()
    {
        firingPoint = transform.position;

    }

   
    void Update()
    {
        MoveProjectile();
    }

    void DamageControl()
    {
        if (currentGun == "handGun")
        {
            currentDamage = 17f;
        }
    }

    public void DestroyBullet()
    {
        Destroy(this.gameObject);
    }

    void MoveProjectile()
    {
        if (Vector3.Distance(firingPoint, transform.position) > MaxDistance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            if (tag == "FireBullet")
            {

                fireBulletAcceleration();
            }
            else if(tag == "ElectricBullet")
            {
                ElectricBulletAcceleration();
            }
            else
            {
                transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
            }
            
        }
        
    }

    void fireBulletAcceleration()
    {
        if(fireSpeed >= projectileSpeed)
        {
            fireSpeed = projectileSpeed;
        }
        else
        {
            float startingspeed = projectileSpeed / 7;
            fireSpeed = (startingspeed + fireBulletAccelerationFigures) + fireSpeed;
            //fireSpeed = (fireSpeed + Time.deltaTime) + fireBulletAccelerationFigures;
        }
        transform.Translate(Vector3.forward * fireSpeed * Time.deltaTime);
    }

    void ElectricBulletAcceleration()
    {
        float startingspeed = projectileSpeed / 4;
        if (electricSpeed >= projectileSpeed)
        {
            electricSpeed = projectileSpeed;
        }
        else
        {
            electricSpeed = (startingspeed + electricBulletAccelerationFigures) + electricSpeed - startingspeed;
        }
        
        transform.Translate(Vector3.forward * electricSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            DestroyBullet();
        }
    }

}
