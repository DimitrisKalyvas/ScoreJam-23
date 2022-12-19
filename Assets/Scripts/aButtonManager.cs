using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aButtonManager : MonoBehaviour
{
    public GameObject ButtonDMG, ButtonFRT;

    public Shooting ShootingScript;
    public GunController DamageScript;
    public EnemySpawner EnemySpawnerScript;
    public GameObject[] Turrets;
    public bool isUpgrading = false;

    void Start()
    {
        ShootingScript = FindObjectOfType<Shooting>();
        EnemySpawnerScript = FindObjectOfType<EnemySpawner>();
        DamageScript = FindObjectOfType<GunController>();
        ButtonDMG = GameObject.Find("UpgradeDamage");
        ButtonFRT = GameObject.Find("UpgradeFireRate");
        ButtonDMG.gameObject.SetActive(false);
        ButtonFRT.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("j"))
        {
            ButtonDMG.gameObject.SetActive(true);
            ButtonFRT.gameObject.SetActive(true);
        }if (Input.GetKeyDown("l"))
        {
            ButtonDMG.gameObject.SetActive(false);
            ButtonFRT.gameObject.SetActive(false);
        }
    }
    public void EnableButtons()
    {
        isUpgrading = true;
        ButtonDMG.gameObject.SetActive(true);
        ButtonFRT.gameObject.SetActive(true);
         
    }
    

    public void SetDmg()
    {
        Debug.Log("setdmg");

        for (int i = 0; i < 3; i++)
        {
            
            Turrets[i].GetComponent<GunController>().Damage +=  2;
        }
        
        
        ButtonDMG.gameObject.SetActive(false);
        ButtonFRT.gameObject.SetActive(false);
        EnemySpawnerScript.UpgradeTime = 0;
        EnemySpawnerScript.stopSpawning = false;
        isUpgrading = false;
        EnemySpawnerScript.ButtonsEnabled = false;

    }

    public void SetFireRate()
    {
        Debug.Log("setfrt");

        for (int i = 0; i < 3; i++)
        {
            
            Turrets[i].GetComponent<Shooting>().fireRate -= 0.2f ;
        }
        
       
        ButtonFRT.gameObject.SetActive(false);
        ButtonDMG.gameObject.SetActive(false);
        EnemySpawnerScript.UpgradeTime = 0;
        EnemySpawnerScript.stopSpawning = false;
        isUpgrading = false;
        EnemySpawnerScript.ButtonsEnabled = false;
    }


}
