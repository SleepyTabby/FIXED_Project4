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
    private float CurrentAmmo;
    private float CurrentElectricAmmo;
    private float CurrentFireAmmo;
    public int Magazine = 2;
    

    private float CurrentMaxAmmo;

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
    
    private bool NormalAmmoLeft;
    private bool ElectricAmmoLeft;
    private bool FireAmmoLeft;

    void Awake()
    {
        Instance = GetComponent<Gun>();
    }
    
    void Start()
    {
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
        Amunition.SetMaxMag(Magazine);
        CurrentMaxAmmo = 20f;
        CurrentAmmo = 20f;
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Magazine != 0)
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
                //if(Magazine > 0)
                //{
                    if (ReloadCountDown != ReloadTime[0])
                    {
                        ReloadCountDown++;
                        adjustAmmo.SetAmmo(ReloadCountDown / 5f);
                    }
                    if (ReloadCountDown >= ReloadTime[0])
                    {
                        CurrentAmmo = 20f;
                        ReloadCountDown = 0f;
                        Magazine -= 1;
                        Amunition.SetMag(Magazine);
                        isReloading = false;
                    }
                    if (CurrentAmmo >= 21f)
                    {
                        CurrentAmmo = 20f;
                    }
                //}
            }
        }
    }
    
    public void GainAmmoByAmmoPack(float ReceiveAmmunition)
    {
        //CurrentAmmo = CurrentAmmo + ReceiveAmmunition;

        //if (CurrentAmmo >= 21f)
        //{
        //    CurrentAmmo = 20f;
        //}

        Magazine += 1;
        Amunition.SetMag(Magazine);
        //adjustAmmo.SetAmmo(CurrentAmmo);

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
                    LastShot = Time.time;
                    Instantiate(bulletNormal, firePoint.position, firePoint.rotation);
                    CurrentAmmo -= 1f;
                    adjustAmmo.SetAmmo(CurrentAmmo);

                }
            }
            if (currentBullet == "electricity")
            {
                if (LastShot + fireSpeedElectricBullet <= Time.time)
                {
                    LastShot = Time.time;
                    Instantiate(bulletElectric, firePoint.position, firePoint.rotation);
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
                    LastShot = Time.time;
                    Instantiate(bulletFire, firePoint.position, firePoint.rotation);
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
        if (CurrentAmmo <= 0f && currentBullet == "normal" && Magazine != 0)
        {
            isReloading = true;
        }

    }
}
