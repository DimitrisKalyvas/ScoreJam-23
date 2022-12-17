using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;
    
    public TotalGunController MasterScript;

    void Start()
    {
        MasterScript = FindObjectOfType<TotalGunController>();
        
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
        if (angle >= -180 && angle <= 0)
        {
            rb.rotation = angle;
        }
        
    }

    


    
}
