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
            transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            DestroyBullet();
        }
    }

}
