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
        SceneManager.LoadScene(escenas, LoadSceneMode.Single);

        DataManager.passLevel();
        DataManager.saveGame();
        DataSave.saveCurrentGame();
    }
}
