﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : Entity
{
    private bool canJump;
    public int coins, skin;
    public DataManager manager;
    public AudioClip jumpSound, walkSound, attackSound, coinSound, buySound;
    
    


    public Player(int health, int strength, int defense) : base(health, strength, defense)
    {
        canJump = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        canJump = true;
        healthBar.fillAmount = 1;
        stats = manager.getStats();
        coins = manager.getCoins();
        skin = manager.getSkinNumber();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 0)); //Para que el player no se caiga, siempre se quede en vertical el sprite
        healthBar.fillAmount = (float)this.GetStatValue(Stat.Health) / 5;
        manager.setStats(stats);    //Se actualizan los datos del DataManager
        manager.setCoins(coins);
        manager.setSkinNumber(skin);
        if (!Input.anyKey)
        {
            GetComponent<AudioSource>().Pause(); //Para pausar el sonido del personaje cuando no hay ninguna tecla presionada
        }
        switch (skin){
            case 1:
                GetComponent<Animator>().SetBool("hero-1", true);
                GetComponent<Animator>().SetBool("hero-2", false);
                break;
            case 2:
                GetComponent<Animator>().SetBool("hero-1", false);
                GetComponent<Animator>().SetBool("hero-2", true);
                break;
            case 3:
                break;
        }
    }


    public void Jump()
    {
        if (canJump)
        {
            GetComponent<AudioSource>().clip = jumpSound; 
            GetComponent<AudioSource>().volume = Random.Range(0.8f,1f);  // Sonido al saltar, y para que suene diferente cada vez que se ejecute. 
            GetComponent<AudioSource>().pitch = Random.Range(0.8f,1.1f); 
            GetComponent<AudioSource>().Play();           
            canJump = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 25000f));
            GetComponent<Animator>().SetBool("jumpping", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground")
        {
            canJump = true;
            GetComponent<Animator>().SetBool("jumpping", false);
        }
    }


    public override void Move()
    {
        
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            if (canJump && !GetComponent<AudioSource>().isPlaying && (Time.timeScale > 0f))
            {
                GetComponent<AudioSource>().clip = walkSound; //Sonido al caminar...
                GetComponent<AudioSource>().volume = Random.Range(0.8f, 1f);  //  para que suene diferente cada vez que se ejecute. 
                GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.1f);
                GetComponent<AudioSource>().Play();
            }
           
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-46000f * Time.deltaTime, 0));  //Se le agrega tanta fuerza por ser una unidad/metro por pixel
            GetComponent<Animator>().SetBool("running", true);
            if (Time.timeScale == 1f)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            if (canJump && !GetComponent<AudioSource>().isPlaying && (Time.timeScale > 0f))

            {

                GetComponent<AudioSource>().clip = walkSound; //Sonido al caminar...
                GetComponent<AudioSource>().volume = Random.Range(0.8f, 1f);  //  para que suene diferente cada vez que se ejecute. 
                GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.1f);
                GetComponent<AudioSource>().Play();
            }
           
            GetComponent<Rigidbody2D>().AddForce(new Vector2(46000f * Time.deltaTime, 0));  //Se le agrega tanta fuerza por ser una unidad/metro por pixel
            GetComponent<Animator>().SetBool("running", true);
            if (Time.timeScale == 1f)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        if (Input.GetKeyDown("w") || Input.GetKeyDown("up") || Input.GetKeyDown("space"))
        {
            Jump();
        }


        if (!(Input.GetKey("a") || Input.GetKey("left")) && !(Input.GetKey("d") || Input.GetKey("right")))
        {
            if (Time.timeScale == 1f)
            {
                GetComponent<Animator>().SetBool("running", false);
            }
        }

    }

    public override void Attack(Entity entity)
    {
        GetComponent<AudioSource>().clip = attackSound; // Sonido al atacar...
        GetComponent<AudioSource>().Play();
        //Especificar según funciones de UNITY
    }

    public int getCoins()
    {
        return this.coins;
    }

    public void takeCoins(int coins)
    {
        GetComponent<AudioSource>().clip = coinSound;  // Sonido al agarrar una moneda...
        GetComponent<AudioSource>().Play();            
        this.coins += coins;
    }

    public void substractCoins(int coins)
    {
        if (coins <= this.coins)
        {
            this.coins -= coins;
            return;
        }
    }

}
