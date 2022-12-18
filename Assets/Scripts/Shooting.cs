using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GunController BaseScript;
    public float bulletForce = 20f;
    private bool CanFire;

    void Start()
    {
        BaseScript = FindObjectOfType<GunController>();
        CanFire = true;
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1") && (CanFire))
        {
            Shoot();
        }
    }


    void Shoot()
    {
        //FindObjectOfType<AudioManager>().Play("Laser_Fire");
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
