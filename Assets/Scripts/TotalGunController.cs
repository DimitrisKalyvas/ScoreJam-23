using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalGunController : MonoBehaviour
{

    public GameObject[] Turrets;
    public GunController BaseScript;
    public Shooting ShootingScript;
    public Animator animator;
    int TurretSelector;


    // Start is called before the first frame update
    void Start()
    {
        BaseScript = FindObjectOfType<GunController>();
        animator = FindObjectOfType<Animator>();
        ShootingScript = FindObjectOfType<Shooting>();
        TurretSelector = 0;

        for (int i = 0; i <3; i++)
        {
            Turrets[i].GetComponent<GunController>().enabled = false;
            Turrets[i].GetComponent<Animator>().enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
       


        if (Input.GetKeyDown("1"))
        {
            DeactivateTurret(TurretSelector);
            TurretSelector = 0;
            ActivateTurret(0);
            EnableTurret(0);
            DisableTurret(1);
            DisableTurret(2);
            
        }
        if (Input.GetKeyDown("2"))
        {
            DeactivateTurret(TurretSelector);
            TurretSelector = 1;
            ActivateTurret(1);
            EnableTurret(1);
            DisableTurret(0);
            DisableTurret(2);
            
        }
        if (Input.GetKeyDown("3"))
        {
            DeactivateTurret(TurretSelector);
            TurretSelector = 2;
            ActivateTurret(2);
            EnableTurret(2);
            DisableTurret(0);
            DisableTurret(1);
            
        }
        
    }

    void EnableTurret(int TurretSelected)
    {
        Turrets[TurretSelected].GetComponent<GunController>().enabled = true;
        Turrets[TurretSelected].GetComponent<Shooting>().enabled = true;
    }
    void DisableTurret(int TurretSelected)
    {
        Turrets[TurretSelected].GetComponent<GunController>().enabled = false;
        Turrets[TurretSelected].GetComponent<Shooting>().enabled = false;
    }

    void ActivateTurret(int TurretSelected)
    {
        Turrets[TurretSelected].GetComponent<Animator>().enabled = true;
        Turrets[TurretSelected].GetComponent<Animator>().SetBool("IsActive", true);
        Turrets[TurretSelected].GetComponent<Animator>().SetBool("IsIdle", false);
    }

    void DeactivateTurret(int TurretSelected)
    {
        Turrets[TurretSelected].GetComponent<Animator>().SetBool("IsActive", false);
        Turrets[TurretSelected].GetComponent<Animator>().SetBool("IsIdle", false);
        
    }

    void IdleTurret(int TurretSelected)
    {
        animator.SetBool("IsActive", false);
        animator.SetBool("IsIdle", true);
    }
}
