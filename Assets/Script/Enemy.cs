using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Attack(Entity entity)
    {
        throw new System.NotImplementedException();
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

}
