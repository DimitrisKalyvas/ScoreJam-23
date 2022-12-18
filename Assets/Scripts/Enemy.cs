using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 5;
    public int hp = 10;
    public GunController BaseScript;
    public GameObject EnemyDeath;
    public Health healthscript;
    public highscore scorescript;
    

    void Start()
    {
        BaseScript = FindObjectOfType<GunController>();
        healthscript = FindObjectOfType<Health>();
        target = GameObject.Find("Earth").transform;
        scorescript = FindObjectOfType<highscore>();
    }

    public void Update()
    {
        float dist = Vector3.Distance(target.position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.gameObject.CompareTag("Bullet"))
        {
            hp -= BaseScript.Damage;
            if(hp <= 0)
            {
                GameObject effect = Instantiate(EnemyDeath, transform.position, Quaternion.identity);
                Destroy(effect, 1.1f);
                Destroy(gameObject);
                scorescript.AddToScore();
            }
        }else if (collision.gameObject.CompareTag("Earth"))
        {
            healthscript.TakeDamage(1);
            GameObject effect = Instantiate(EnemyDeath, transform.position, Quaternion.identity);
            Destroy(effect, 1.1f);
            Destroy(gameObject);
        }
    }

}
