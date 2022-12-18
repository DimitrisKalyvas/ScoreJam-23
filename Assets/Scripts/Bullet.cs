using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;
    public Health healthscript;


    void Start()
    {
        healthscript = FindObjectOfType<Health>();
    }


    void OnCollisionEnter2D(Collision2D collision){

        if (collision.gameObject.CompareTag("Earth"))
        {
            healthscript.TakeDamage(1);
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("EarthDamage");
            Destroy(effect, 5f);
            Destroy(gameObject);
        }
        else
        {

            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().Play("Explosion");
            Destroy(effect, 5f);
            Destroy(gameObject);
        }
    }

}
