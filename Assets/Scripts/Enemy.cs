using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 5;

    void Start()
    {
        target = GameObject.Find("Earth").transform;
    }

    public void Update()
    {

        float dist = Vector3.Distance(target.position, transform.position);




        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);

    }
}
