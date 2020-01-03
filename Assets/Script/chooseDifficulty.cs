using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chooseDifficulty : MonoBehaviour
{
    public DataManager manager;

    public void difficultyChosen(int difficulty)
    {
        manager.setDifficulty(difficulty);
        SceneManager.LoadScene("select skin", LoadSceneMode.Single);
    }
}
