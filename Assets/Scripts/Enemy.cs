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
    public int point;
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
                int num = Random.Range(1, 6);
                if (num == 1)
                {
                    FindObjectOfType<AudioManager>().Play("Alien_Death1");
                }else if ( num == 2)
                {
                    FindObjectOfType<AudioManager>().Play("Alien_Death2");
                }
                else if (num == 3)
                {
                    FindObjectOfType<AudioManager>().Play("Alien_Death3");
                }
                else if (num == 4)
                {
                    FindObjectOfType<AudioManager>().Play("Alien_Death4");
                }
                else if (num == 5)
                {
                    FindObjectOfType<AudioManager>().Play("Alien_Death5");
                }
                else if (num == 6)
                {
                    FindObjectOfType<AudioManager>().Play("Alien_Death6");
                }

                GameObject effect = Instantiate(EnemyDeath, transform.position, Quaternion.identity);
                Destroy(effect, 1.1f);
                Destroy(gameObject);
                scorescript.AddToScore(point);
            }
        }else if (collision.gameObject.CompareTag("Earth"))
        {
            FindObjectOfType<AudioManager>().Play("EarthDamage");
            healthscript.TakeDamage(1);
            GameObject effect = Instantiate(EnemyDeath, transform.position, Quaternion.identity);
            Destroy(effect, 1.1f);
            Destroy(gameObject);
        }
    }

}
