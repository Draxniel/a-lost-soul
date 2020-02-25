using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGate : MonoBehaviour
{
    public string escenas;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((DataManager.level == 4) && (DataManager.getGoldenSkulls() == 6))
        {
            SceneManager.LoadScene("easter egg", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene(escenas, LoadSceneMode.Single);
        }
        DataManager.saveGame(true);
        DataSave.saveCurrentGame();
    }

    public void loadScene()
    {
        SceneManager.LoadScene(escenas, LoadSceneMode.Single);
        DataManager.saveGame(true);
        DataSave.saveCurrentGame();
    }
}
