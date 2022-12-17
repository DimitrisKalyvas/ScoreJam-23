using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;
    public float MinAngle,MaxAngle;
    GameObject[] points;
    
    
    public TotalGunController MasterScript;

    void Start()
    {
        MasterScript = FindObjectOfType<TotalGunController>();
        
        Debug.Log(gameObject.transform.rotation.z);
    }


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        
    }

    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = (Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f);
        Debug.Log(angle);
         
             rb.rotation = angle;
        

        

    }

    


    
}
