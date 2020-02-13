using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : Entity
{
    private bool canJump, attacking, canAttack;
    private float attackTime;
    private int coins, skin, maxHealth, damageMultiplier;
    public DataManager manager;
    public AudioClip jumpSound, walkSound, attackSound;
    public GameObject attackObject;
    public Text life, CoinNumber,Stronger,Defense;


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
        maxHealth = manager.getMaxHealth();
        damageMultiplier = manager.getDifficulty();
        attackTime = 5;
        attackObject.SetActive(false);
        attacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (stats[Stat.Health] > 0)
        {
            Move();
            AttackAnim();
        }
        else
        {
            GetComponent<Animator>().SetBool("dead", true);
            GetComponent<Animator>().SetBool("attack", false);
            GetComponent<Animator>().SetBool("running", false);
            GetComponent<Animator>().SetBool("jumpping", false);
        }

        attackObject.GetComponent<Transform>().position = this.GetComponent<Transform>().position; 

        healthBar.fillAmount = (float)this.GetStatValue(Stat.Health) / maxHealth;   //Se llena la barra de vida

        manager.setStats(stats);    //Se actualizan los datos del DataManager
        manager.setCoins(coins);
        manager.setSkinNumber(skin);
        manager.setMaxHealth(maxHealth);

       

        //Falta detectar que no esta tocando suelo para desactivar el sonido de las patas

        switch (skin) { //Seleccion de skin
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

        life.text = (GetStatValue(Stat.Health)).ToString();
        CoinNumber.text = (getCoins()).ToString();
        Defense.text = (GetStatValue(Stat.Defense)).ToString();
        Stronger.text = (GetStatValue(Stat.Strength)).ToString();

    }

    public override void TakeDamage(int damage) 
    {
        if (GetStatValue(Stat.Health) > 0)
        {
            if ((damage * damageMultiplier) <= GetStatValue(Stat.Health))
            {
                this.stats[Stat.Health] -= (damage * damageMultiplier);
                return;
            }
            stats[Stat.Health] = 0;
        }
    }

    public void Jump()
    {
        if (canJump)
        {
            GetComponent<AudioSource>().clip = jumpSound;
            GetComponent<AudioSource>().volume = Random.Range(0.8f, 1f);  // Sonido al saltar, y para que suene diferente cada vez que se ejecute. 
            GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.1f);
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

            if ((Time.timeScale == 1f) && (!attacking))
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

            if ((Time.timeScale == 1f) && (!attacking))
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

        if (!(Input.GetKey("a") || Input.GetKey("left")) && !(Input.GetKey("d") || Input.GetKey("right")) && canJump)
        {
            GetComponent<AudioSource>().Pause();
        }

    }

    public override void Attack(Entity enemy)
    {
        if (canAttack)
        {
            enemy.TakeDamage(GetStatValue(Stat.Strength));
            canAttack = false;
        }
    }

    public void AttackAnim()
    {
        if (Input.GetKeyDown("b") || (attackTime <= 0.8f))   //Validación para hacer animacion de ataque
        {
            if (attackTime > 0.8f)
            {
                attackTime = 0;
                canAttack = true;
            }
            else
            {
                GetComponent<Animator>().SetBool("attack", true);
                GetComponent<AudioSource>().clip = attackSound;
                if(!GetComponent<AudioSource>().isPlaying)
                    GetComponent<AudioSource>().Play();
                GetComponent<Animator>().SetBool("running", false);
                GetComponent<Animator>().SetBool("jumpping", false);
                attackTime += Time.deltaTime;
                attackObject.SetActive(true);
                attacking = true;
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("attack", false);
            attackObject.SetActive(false);
            canAttack = false;
            attacking = false;
        }
    }

    public int getCoins()
    {
        return this.coins;
    }

    public void takeCoins(int coins)
    {
        this.coins += coins;
    }

    public void substractCoins(int coins)
    {
        if (coins <= this.coins)
        {
            this.coins -= coins;
        }
    }

    public void takeBoost(Item item)
    {
        stats[item.getStat()] += item.getValue();
        if (stats[Stat.Health] > maxHealth)
        {
            maxHealth = stats[Stat.Health];
        }
    }
}
