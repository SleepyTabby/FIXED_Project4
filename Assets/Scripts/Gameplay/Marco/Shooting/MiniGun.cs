using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGun : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private CameraFollow camera;
    [SerializeField] Transform player;
    [SerializeField] Gun enable;
    [Header("All Bullet prefabs")]
    [SerializeField] private GameObject bulletFire;
    
    [SerializeField] private float fireSpeedFireBullet;
    public bool pressurePlate;

    public static MiniGun Instance;
    float LastShot = 0f;
    [Header("spray")]
    [Range(0f, 5f)]
    [SerializeField] float fireSpray;

    void Awake()
    {
        Instance = GetComponent<MiniGun>();
    }

    private void Update()
    {
        
    }


    void RotateMiniGun()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(player);
        }

    }

    public void Shoot()
    {
        if (pressurePlate)
        {
            camera.offset = new Vector3(0, 15, 0);
            RotateMiniGun();
            if (LastShot + fireSpeedFireBullet <= Time.time)
            {
                float randomSpray = Random.Range(firePoint.rotation.y - fireSpray, firePoint.rotation.y + fireSpray);
                Quaternion spray = new Quaternion(firePoint.rotation.x, randomSpray, firePoint.rotation.z, firePoint.rotation.w);
                LastShot = Time.time;
                Instantiate(bulletFire, firePoint.position, spray);
            }
        }
    }
}
