using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Entity : MonoBehaviour
{

    protected Dictionary<Stat, int> stats;
    public Image healthBar;

    public Entity(int health, int strength, int defense)
    {
        stats = new Dictionary<Stat, int>();
        stats.Add(Stat.Health, health);
        stats.Add(Stat.Strength, strength);
        stats.Add(Stat.Defense, defense);
    }

    public abstract void Move();

    public abstract void Attack(Entity entity);

    public int GetStatValue(Stat stat)
    {
        return (this.stats[stat]);
    }

    public void setStatValue(Stat stat, int value)
    {
        this.stats[stat] = value;
    }

    public abstract void TakeDamage(int damage);

   

}
