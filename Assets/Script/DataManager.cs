using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{

    public static DataManager manager;
    private Dictionary<Stat, int> stats;
    public int maxHealth;
    public int coins;
    public int skin;
    public int difficulty;
    public static int level;
    private PlayerData data;
    public static int goldenSkulls;
    public static bool storeSkull = false;
    private void Awake()    //Se ejecuta antes de Start()
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
            level = 1;
            goldenSkulls = 0;
        }
        else if (manager != this)   //Para las siguientes instancias de la clase, el atributo estático sigue siendo el anterior asignado, entonces iguala los datos que este tenga para replicarlos en el nivel
        {
            stats = manager.getStats();
            coins = manager.getCoins();
            skin = manager.getSkinNumber();
            difficulty = manager.getDifficulty();
            maxHealth = manager.getMaxHealth();
            level = manager.getLevel();
            goldenSkulls = manager.getGoldenSkulls();
            if (stats[Stat.Health] == 0)    //Si el player muere, se reestablecen los datos de la instancia actual
            {
                if (level == 1){
                    maxHealth = 5;
                    stats[Stat.Health] = maxHealth;
                    stats[Stat.Defense] = 1;
                    stats[Stat.Strength] = 1;
                }
                else
                {
                    manager.loadGame();
                    maxHealth = manager.maxHealth;
                    stats[Stat.Health] = maxHealth;
                    stats[Stat.Defense] = manager.stats[Stat.Defense];
                    stats[Stat.Strength] = manager.stats[Stat.Strength];
                    goldenSkulls = manager.getGoldenSkulls();
                }
                coins = 0;
            }
        }
        data = DataSave.loadCurrentGame();
        if (Checkpoint.isGameLoaded)
        {
            maxHealth = data.maxHealth;
            stats[Stat.Health] = maxHealth;
            stats[Stat.Defense] = data.stats[Stat.Defense];
            stats[Stat.Strength] = data.stats[Stat.Strength]; ;
            coins = data.coins;
            skin = data.skin;
            level = data.level;
            goldenSkulls = data.goldenSkulls;
        }
    }

    private void Update()   //Se actualizan los datos del atributo estático
    {
        updateManager();
    }

    public void updateManager()
    {
        manager.setStats(stats);
        manager.setSkinNumber(skin);
        manager.setMaxHealth(maxHealth);
        manager.setDifficulty(difficulty);
        manager.setCoins(coins);
    }

    public void passLevel()
    {
        level += 1;
    }
    public void setLevel(int levelNumber)
    {
        level = levelNumber;
    }
    public int getLevel()
    {
        return level;
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
    public static void saveGame(bool level)
    {
        manager.updateManager();
        if (level)
        {
            manager.passLevel();
        }
        Checkpoint.saveData(manager);

    }
    public void loadGame()
    {
       manager = Checkpoint.loadData();
    }

    public int getGoldenSkulls()
    {
        return goldenSkulls;
    }
    public static void foundGoldenSkull()
    {
        goldenSkulls++;
    }

}