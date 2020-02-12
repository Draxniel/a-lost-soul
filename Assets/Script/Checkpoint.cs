using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Checkpoint
{
    public static bool isGameLoaded = false;
    public static DataManager gameSave;
    public static void saveData(DataManager data)
    {
        gameSave = data;
    }
    public static DataManager loadData()
    {
        return gameSave;
    }
}
