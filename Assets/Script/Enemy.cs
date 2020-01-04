using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{

    public Player player;
    float attackTime;

    public Enemy(int health, int strength, int defense) : base(health, strength, defense)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        stats = new Dictionary<Stat, int>();
        stats.Add(Stat.Health, 5);
        stats.Add(Stat.Strength, 1);
        stats.Add(Stat.Defense, 1);
        healthBar.fillAmount = 1;
        attackTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        attackTime += Time.deltaTime;
    }

    public override void Attack()
    {
        if (attackTime > 1.5f)
        {
            attackTime = 0;
            player.TakeDamage(GetStatValue(Stat.Strength));
        }
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "attack")
        {
            TakeDamage(player.GetStatValue(Stat.Strength));
        }
        else if (collision.transform.tag == "Player")
        {
            Attack();
        }

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
}
