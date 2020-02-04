using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData 
{
    public int level;
    public int skin;
    public int coins;
    public Dictionary<Stat, int> stats;
    public int maxHealth;
    public int difficulty;

    public PlayerData()
    {
        level = Checkpoint.gameSave.getLevel();
        skin = Checkpoint.gameSave.getSkinNumber();
        coins = Checkpoint.gameSave.getCoins();
        maxHealth = Checkpoint.gameSave.getMaxHealth();
        difficulty = Checkpoint.gameSave.getDifficulty();
        stats = Checkpoint.gameSave.getStats();
    }
}
