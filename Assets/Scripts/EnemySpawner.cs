using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 1, time = 3f;
    public GameObject[] enemies;


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





}
