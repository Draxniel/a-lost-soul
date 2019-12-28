using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausaUI;
    public static bool gamePaused;

    void Start()
    {
        gamePaused = false;
        pausaUI.SetActive(false);
        Time.timeScale = 1f;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) {
            if (gamePaused) {
                resume();
            }
            else {
                pause();
            }
        }
    }
     public void resume() {
        pausaUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }
    void pause() {
        Time.timeScale = 0f;
        pausaUI.SetActive(true);   
        gamePaused = true;
    }
    public void QuitGame() {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
