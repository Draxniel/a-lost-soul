using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public static DataManager manager;
    private Dictionary<Stat, int> stats;
    private int coins, maxHealth; 
    public int skin;
    public int difficulty;

    private void Awake()
    {
        if (manager == null)    //Esto ocurre en la primera instancia de la clase
        {
            DontDestroyOnLoad(gameObject);
            stats = new Dictionary<Stat, int>();
            maxHealth = 5;
            stats.Add(Stat.Health, maxHealth);
            stats.Add(Stat.Strength, 1);
            stats.Add(Stat.Defense, 1);
            coins = 0;
            manager = this; //Entonces se asigna este objeto a la variable estática para mantenerse en la ejecución de todo el juego
            skin = 1;
            difficulty = 1;
        }
        else if (manager != this)   //Para las siguientes instancias de la clase, el atributo estático sigue siendo el anterior asignado, entonces iguala los datos que este tenga para replicarlos en el nivel
        {
            stats = manager.getStats();
            coins = manager.getCoins();
            skin = manager.getSkinNumber();
            difficulty = manager.getDifficulty();
            maxHealth = manager.getMaxHealth();
            if (stats[Stat.Health] == 0)    //Si el player muere, se reestablecen los datos de la instancia actual
            {
                maxHealth = 5;
                stats[Stat.Health] = maxHealth;
                stats[Stat.Strength] = 1;
                stats[Stat.Defense] = 1;
                coins = 0;
            }
        }
    }

    private void Update()   //Se actualizan los datos del atributo estático
    {
        manager.setStats(stats);
        manager.setCoins(coins);
        manager.setSkinNumber(skin);
        manager.setMaxHealth(maxHealth);
        manager.setDifficulty(difficulty);
    }

    public Dictionary<Stat, int> getStats()
    {
        return stats;
    }

    public int getCoins()
    {
        return coins;
    }

    public void setStats(Dictionary<Stat, int> stat)
    {
        stats = stat;
    }

    public void setCoins(int coin)
    {
        coins = coin;
    }

    public int getSkinNumber()
    {
        return skin;
    }

    public void setSkinNumber(int skin)
    {
        this.skin = skin;
    }

    public int getDifficulty() {
        return this.difficulty;
    }
    public void setDifficulty(int difficulty)
    {
        this.difficulty = difficulty;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public void setMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }
}