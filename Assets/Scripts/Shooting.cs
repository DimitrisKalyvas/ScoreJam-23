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

    void Start()
    {
        BaseScript = FindObjectOfType<GunController>();
        TGC = FindObjectOfType<TotalGunController>();
        CanFire = false;
        done = false;

    }


    void Update()
    {

        if (done == false)
        {
            if (Input.GetKeyDown("1"))
            {
                CanFire = true;
                done = true;
                Debug.Log("bruh");
            }
            if (Input.GetKeyDown("2"))
            {
                CanFire = true;
                done = true;
                Debug.Log("bruh");
            }
            if (Input.GetKeyDown("3"))
            {
                CanFire = true;
                done = true;
                Debug.Log("bruh");
            }
        }


        if (Input.GetButtonDown("Fire1") && (CanFire))
        {
            Shoot();
        }
    }


    void Shoot()
    {
        FindObjectOfType<AudioManager>().Play("Laser_Fire");
        CanFire = false;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        Invoke("EnableCanFire", BaseScript.firerate);
    }

    void EnableCanFire()
    {
        CanFire = true;
    }
}
