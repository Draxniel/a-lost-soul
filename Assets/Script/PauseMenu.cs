using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausaUI;
    public static bool gamePaused;
    public static bool canPause;

    void Start()
    {
        canPause = true;
        gamePaused = false;
        pausaUI.SetActive(false);
        Time.timeScale = 1f;
    }
    
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && (canPause)) {
            if (gamePaused) {
                resume();
            }
            else {
                pausaUI.SetActive(true);
                pause();
                SoundController.pauseSound();
            }
        }
    }
     public void resume() {
        Camera.main.GetComponent<AudioSource>().UnPause();
        pausaUI.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }
    void pause() {
        Camera.main.GetComponent<AudioSource>().Pause();
        Time.timeScale = 0f;
        pausaUI.SetActive(true);   
        gamePaused = true;
    }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu secundario", LoadSceneMode.Single);
        pausaUI.SetActive(false);
    }
}
