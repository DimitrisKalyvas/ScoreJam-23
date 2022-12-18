using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 1, time = 4f;
    public GameObject[] enemies;
    private float timer = 0f;

    void Start()
    {
        StartCoroutine(SpawnAnEnemy());
    }

    IEnumerator SpawnAnEnemy()
    {
        Vector2 spawnPos = GameObject.Find("EarthAnimation").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        int random = Random.Range(0, 100);
        if (random < 75)
        {
            Instantiate(enemies[0], spawnPos, Quaternion.identity);
        }
        else if(random > 75)
        {
            Instantiate(enemies[1], spawnPos, Quaternion.identity);
        }
        yield return new WaitForSeconds(time);
        StartCoroutine(SpawnAnEnemy());
    }

    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer > 30)
        {
            time -= 0.5f;
            timer = 0f;
        }
        Debug.Log(timer);
    }




}
