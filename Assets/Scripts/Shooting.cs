using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public GunController BaseScript;
    public float bulletForce = 20f;
    public bool CanFire;
    public bool done;
    public TotalGunController TGC;
    public float fireRate = 1f;
    public GameObject ButtonFRT, ButtonDMG;
    public aButtonManager buttonManager;
    public float time;


    void Start()
    {
        ButtonFRT = GameObject.Find("UpgradeFireRate");
        ButtonDMG = GameObject.Find("UpgradeDamage");
        BaseScript = FindObjectOfType<GunController>();
        buttonManager = FindObjectOfType<aButtonManager>();
        TGC = FindObjectOfType<TotalGunController>();
        CanFire = true;
        done = false;
        fireRate = 1f;
    }

   

    void Update()
    {
        


            


        Debug.Log(fireRate);
        if (Input.GetButtonDown("Fire1") && (time >= fireRate))
        {
            Shoot();
        }


    }


    void Shoot()
    {
        if (buttonManager.isUpgrading == false)
        {
            FindObjectOfType<AudioManager>().Play("Laser_Fire");
            CanFire = false;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            time = 0;
        }
    }

    void EnableCanFire()
    {
        CanFire = true;
    }

    

    
    
}




