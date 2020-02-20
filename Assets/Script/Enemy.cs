using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public Player player;
    public DataManager manager;
    public int maxhealth;   //POR QUE ES PUBLICO ESTE ATRIBUTO??? PREGUNTÓ DANIEL 
    public HealthBar enemyHealth;
    protected int speed, health, damageMultiplier;
    protected float visionRadius, attackkRadius, attackWait, attackTime, timer;
    protected bool attacking, canAttack;
    protected Vector3 initialPosition;
    

    public Enemy(int health, int strength, int defense) : base(health, strength, defense)
    {

    }

    public override void Attack(Entity player)
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "attack")
        {
            player.Attack(this);
        }
        else if ((collision.transform.tag == "Player") && (player.isPlayerAlive()))
        {
            Attack(player);
        }
    }

    public override void TakeDamage(int damage)
    {
        if (GetStatValue(Stat.Health) > 0)
        {
            if (damage <= GetStatValue(Stat.Health))
            {
                this.stats[Stat.Health] -= damage;
                enemyHealth.setActive(true);
                enemyHealth.setHealth(this.stats[Stat.Health]);
                return;
            }
            stats[Stat.Health] = 0;
        }
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.DrawWireSphere(transform.position, attackkRadius);
    }

}
