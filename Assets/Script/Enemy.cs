using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    private bool dead, attacking, canAttack;
    private float attackTime, timer;
    public Player player;
    public int health;

    public Enemy(int health, int strength, int defense) : base(health, strength, defense)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        stats = new Dictionary<Stat, int>();
        stats.Add(Stat.Health, health);
        stats.Add(Stat.Strength, 1);
        stats.Add(Stat.Defense, 1);
        //healthBar.fillAmount = 1;
        attackTime = 0;
        attacking = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        health = GetStatValue(Stat.Health);
        if (GetStatValue(Stat.Health) == 0)
        {
            timer += Time.deltaTime;
            GetComponent<Animator>().SetBool("dead", true); //BOOL PARA ANIMACION DE MUERTE
            if (timer >= 1) //Este tiempo se modifica según la duración de l animación de muerte
            {
                gameObject.SetActive(false);
            }
        }
        if (attacking)
        {
            attackTime += Time.deltaTime;
        }
        if ((attackTime >= 1) && (!canAttack))  //Se valida esto para quitar la animcacion de ataque cuando termine y no cortarle en plena ejecucion
        {
            GetComponent<Animator>().SetBool("attack", false);  //BOOL PARA ANIMACION DE ATAQUE
            attackTime = 0;
            attacking = false;
        }
    }

    public override void Attack(Entity player)
    {
        attacking = true;
        if (attackTime >= 1)    //Este tiempo de ataque se modifica según la duracion de la animacion del ataque
        {
            attackTime = 0;
            if (player.GetStatValue(Stat.Health) > 0)
            {
                GetComponent<Animator>().SetBool("attack", true);
                player.TakeDamage(GetStatValue(Stat.Strength));
            }
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "attack")
        {
            player.Attack(this);
        }
        else if (collision.transform.tag == "Player")
        {
            Attack(player);
            canAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canAttack = false;
    }

    public override void TakeDamage(int damage)
    {
        if (GetStatValue(Stat.Health) > 0)
        {
            if (damage <= GetStatValue(Stat.Health))
            {
                this.stats[Stat.Health] -= damage;
                return;
            }
            stats[Stat.Health] = 0;
        }
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

}
