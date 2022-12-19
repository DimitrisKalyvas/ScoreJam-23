using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;
    GameObject[] points;
    public int Damage;
    public float firerate;
    public GameObject[] TurretsArray;
    public GameObject ButtonDMG, ButtonFRT;


    public TotalGunController MasterScript;

    void Start()
    {
        ButtonDMG = GameObject.Find("UpgradeDamage");
        ButtonFRT = GameObject.Find("UpgradeFireRate");
        MasterScript = FindObjectOfType<TotalGunController>();
        Damage = 5;
        firerate = 1f; 
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
        
         
         rb.rotation = angle;
        

        

    }

    


    
}
