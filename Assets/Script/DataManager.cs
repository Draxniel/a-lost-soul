using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public static DataManager manager;
    private Dictionary<Stat, int> stats;
    private int coins;

    private void Awake()
    {
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            stats = new Dictionary<Stat, int>();
            stats.Add(Stat.Health, 5);
            stats.Add(Stat.Strength, 1);
            stats.Add(Stat.Defense, 1);
            coins = 0;
            manager = this;
        }else if (manager != this)
        {
            stats = manager.getStats();
            coins = manager.getCoins();
        }
    }

    private void Update()
    {
        manager.setStats(stats);
        manager.setCoins(coins);
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
}
