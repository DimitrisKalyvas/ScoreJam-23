using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 1, time = 5f;
    public GameObject[] enemies;
    public float timer = 0f,UpgradeTime = 0f;
    public GameObject ButtonDMG, ButtonFRT;
    public aButtonManager ButtonManagerScript;
    public bool stopSpawning = false;
    public GameObject[] gameObjects;
    public bool ButtonsEnabled = false;

    void Start()
    {
        ButtonManagerScript = FindObjectOfType<aButtonManager>();
        ButtonDMG = GameObject.Find("UpgradeDamage");
        ButtonFRT = GameObject.Find("UpgradeFireRate");
        StartCoroutine(SpawnAnEnemy());
    }

    IEnumerator SpawnAnEnemy()
    {
        Vector2 spawnPos = GameObject.Find("EarthAnimation").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;
        if (stopSpawning == false)
        {
            int random = Random.Range(0, 100);
            if (random < 75)
            {
                Instantiate(enemies[0], spawnPos, Quaternion.identity);
            }
            else if (random > 75)
            {
                Instantiate(enemies[1], spawnPos, Quaternion.identity);
            }
        }
        yield return new WaitForSeconds(time);
        
            StartCoroutine(SpawnAnEnemy());
        
    }

    void Update()
    {
        UpgradeTime += Time.deltaTime;
        timer += Time.deltaTime;
        
        if (UpgradeTime >= 60)
        {
            stopSpawning = true;
            gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
            if (gameObjects.Length == 0 && ButtonsEnabled == false)
            {
                ButtonsEnabled = true;
                ButtonManagerScript.EnableButtons();
            }
            
            
        }

        if (timer > 30)
        {
            time -= 0.5f;
            timer = 0f;
        }
       // Debug.Log(timer);
    }

   


}
