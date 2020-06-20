using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [Header("All Bullet prefabs")]
    [SerializeField] private GameObject bulletNormal;
    [SerializeField] private GameObject bulletElectric;
    [SerializeField] private GameObject bulletFire;
    [Header("Set Bullet Speeds")]
    [SerializeField] private float fireSpeedNormalBullet;
    [SerializeField] private float fireSpeedElectricBullet;
    [SerializeField] private float fireSpeedFireBullet;

    private bool PassiveMode;
    public float CurrentAmmo;
    private float CurrentElectricAmmo;
    private float CurrentFireAmmo;
    

    private float CurrentMaxAmmo;
    [SerializeField]int currentMags;
    private string CurrentGun;
    float[] ReloadTime = { 100f, 150f, 200f, 250f };
    string currentBullet;
    private bool isReloading;
    [SerializeField] private float ReloadCountDown;
    public static Gun Instance;
    float LastShot = 0f;
    [Header("Ammo bars")]
    public AmmoBar adjustAmmo;
    public ElectricAmmoBar adjustElectricAmmo;
    public FireAmmoBar adjustFireAmmo;
    public AmmoPool Amunition;
    
    
    [Header("gunAmmo")]
    private bool NormalAmmoLeft;
    private bool ElectricAmmoLeft;
    private bool FireAmmoLeft;
    public int totalAmmo;
    [Header("spray")]
    [Range(0f, 0.5f)]
    [SerializeField] float normalSpray;
    [SerializeField] int PistolAmmo;
    [Range(0f, 0.5f)]
    [SerializeField] float electricSpray;
    [Range(0f, 0.5f)]
    [SerializeField] float fireSpray;

    void Awake()
    {
        Instance = GetComponent<Gun>();
    }
    
    void Start()
    {
        
        currentMags = Mathf.RoundToInt(totalAmmo / PistolAmmo);
        CurrentGun = "Pistol";
        currentBullet = "normal";
        NormalAmmoLeft = true;
        ElectricAmmoLeft = true;
        FireAmmoLeft = true;
        CurrentElectricAmmo = 10f;
        adjustElectricAmmo.SetMaxAmmo(10f);
        CurrentFireAmmo = 40f;
        adjustFireAmmo.SetMaxAmmo(40f);
        adjustAmmo.SetMaxAmmo(20f);
        CurrentMaxAmmo = 20f;
        CurrentAmmo = 20f;
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (totalAmmo != 0)
            {
                CurrentAmmo = 0;
                adjustAmmo.SetAmmo(CurrentAmmo);
                isReloading = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //normal
            if (NormalAmmoLeft)
            {
                currentBullet = "normal";
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //electricity
            if (ElectricAmmoLeft)
            {
                currentBullet = "electricity";
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //fire
            if (FireAmmoLeft)
            {
                currentBullet = "fire";           
            }
        }

    }
    void FixedUpdate()
    {
        if (isReloading)
        {
            if (CurrentGun == "Pistol")
            {
                if (ReloadCountDown != ReloadTime[0])
                {
                    ReloadCountDown++;
                    adjustAmmo.SetAmmo(ReloadCountDown / 5f);
                }
                if (ReloadCountDown >= ReloadTime[0])
                {
                    totalAmmo -= 20;
                    currentMags = Mathf.RoundToInt(totalAmmo / PistolAmmo);
                    Amunition.SetMag(currentMags);
                    if (currentMags != 0)
                    {
                        CurrentAmmo = 20f;
                    }
                    //else
                    //{
                    //    CurrentAmmo = totalAmmo;
                    //}
                    ReloadCountDown = 0f;
                    isReloading = false;
                }
            }
        }
    }
    
    

    public void SetCurrentGunAmmo(float maxAmmo, string GunName )
    {
        CurrentMaxAmmo = maxAmmo;
        CurrentAmmo = maxAmmo;
        adjustAmmo.SetMaxAmmo(maxAmmo);
        CurrentGun = GunName;
    }

    public void SetCurrentPassiveMode(bool Passive)
    {
        PassiveMode = Passive;
    }

    public void Shoot()
    {
        if (!PassiveMode)
        {

            if (CurrentAmmo >= 0f && isReloading == false && currentBullet == "normal")
            {
                if (LastShot + fireSpeedNormalBullet <= Time.time)
                {
                    //spray
                    float randomSpray = Random.Range(firePoint.rotation.y - normalSpray, firePoint.rotation.y + normalSpray);
                    Quaternion spray = new Quaternion(firePoint.rotation.x, randomSpray, firePoint.rotation.z, firePoint.rotation.w);
                    //time
                    LastShot = Time.time;
                    //fire bullet
                    Instantiate(bulletNormal, firePoint.position, spray);
                    CurrentAmmo -= 1f;
                    adjustAmmo.SetAmmo(CurrentAmmo);
                }
            }
            if (currentBullet == "electricity")
            {
                if (LastShot + fireSpeedElectricBullet <= Time.time)
                {
                    float randomSpray = Random.Range(firePoint.rotation.y - electricSpray, firePoint.rotation.y + electricSpray);
                    Quaternion spray = new Quaternion(firePoint.rotation.x, randomSpray, firePoint.rotation.z, firePoint.rotation.w);
                    LastShot = Time.time;
                    Instantiate(bulletElectric, firePoint.position, spray);
                    CurrentElectricAmmo -= 1f;
                    adjustElectricAmmo.SetAmmo(CurrentElectricAmmo);
                    if (CurrentElectricAmmo <= 0)
                    {
                        ElectricAmmoLeft = false;
                        currentBullet = "normal";
                    }
                }
            }
            if (currentBullet == "fire")
            {
                if (LastShot + fireSpeedFireBullet <= Time.time)
                {
                    float randomSpray = Random.Range(firePoint.rotation.y - fireSpray, firePoint.rotation.y + fireSpray);
                    Quaternion spray = new Quaternion(firePoint.rotation.x, randomSpray, firePoint.rotation.z, firePoint.rotation.w);
                    LastShot = Time.time;
                    Instantiate(bulletFire, firePoint.position, spray);
                    CurrentFireAmmo -= 1f;
                    adjustFireAmmo.SetAmmo(CurrentFireAmmo);
                    if (CurrentFireAmmo <= 0)
                    {
                        FireAmmoLeft = false;
                        currentBullet = "normal";
                    }
                }
            }
        }
        if (CurrentAmmo <= 0f && currentBullet == "normal") 
        {
            isReloading = true;
        }

    }
}
