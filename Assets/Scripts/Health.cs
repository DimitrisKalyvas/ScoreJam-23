using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Health : MonoBehaviour
{

    
    public int health;
    public int numOfHearts;
    public GameObject GameOverScreen;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameOverScreen gameover;

    void Awake()
    {
        GameOverScreen = GameObject.Find("Backround");
    }

    void Start()
    {
        Time.timeScale = 1;
        gameover = FindObjectOfType<GameOverScreen>();
        

    }
    void Update()
    {

        if(health > numOfHearts){
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++){
            if(i < health){
                hearts[i].sprite = fullHeart;
            }
            else
                hearts[i].sprite = emptyHeart;
            
            if(i < numOfHearts){
                hearts[i].enabled = true;
            }
            else
                hearts[i].enabled = false;

        }
    }

    public void TakeDamage(int dmg)
    {
        
        health -= dmg;
        if (health <=0)
        {
            
            FindObjectOfType<AudioManager>().Play("Alien_Laugh");
            gameover.EnableGameOverMenu();
            Time.timeScale = 0;
        }
    }

}
