using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverM : MonoBehaviour
{
    public Player player;
    public GameObject finDelJuego;
    public string nivel;
    public bool game;
   
    

    // Update is called once per frame
    void Start()
    {
        game = false;
        finDelJuego.SetActive(false);
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (player.GetStatValue(Stat.Health) < 0)
        {
            player.setStatValue(Stat.Health, 0);
        }
            if (player.GetStatValue(Stat.Health) == 0)
        {
            finDelJuego.SetActive(true);
            player.GetComponent<Animator>().SetBool("dead", true);
            player.GetComponent<Animator>().SetBool("running", false);
            player.GetComponent<Animator>().SetBool("jumpping", false);
            player.GetComponent<Animator>().SetBool("attack", false);
            //Time.timeScale = 0f;
        }
    }
    public void Loadscena()
    {
        SceneManager.LoadScene(nivel);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}