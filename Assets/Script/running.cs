using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class running : MonoBehaviour
{
    public int skin;
    public DataManager manager;
    public float parallaxSpeed = 0.2f;
    public RawImage backGround;
    public RawImage floorPic;
    public GameObject playButton, loadButton, exitButton;
    private float time;

    void Start()
    {
        GetComponent<AudioSource>().PlayDelayed(1f); // Activa la música después de 1 seg...
        if ((playButton) && (loadButton) && (exitButton))
        {
            playButton.SetActive(false);
            loadButton.SetActive(false);
            exitButton.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void FixedUpdate() //Update
    {
        time += Time.deltaTime;
        switch (skin)
        {
            case 1:
                GetComponent<Animator>().SetBool("Hero2", false);
                break;
            case 2:
                GetComponent<Animator>().SetBool("Hero2", true);
                break;
            case 3:
                break;
        }
        float finalSpeed = parallaxSpeed * Time.deltaTime;
        if (gameObject.transform.position.x < 0f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.08f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        floorPic.uvRect = new Rect(floorPic.uvRect.x + (finalSpeed/2), 0f, 1f, 1f);
        backGround.uvRect = new Rect(backGround.uvRect.x + finalSpeed, 0f, 1f, 1f);
        if ((time > 21) && (playButton) && (loadButton) && (exitButton))
        {
            playButton.SetActive(true);
            loadButton.SetActive(true);
            exitButton.SetActive(true);
        }
    }

    public void play()
    {
        Checkpoint.isGameLoaded = false;
        SceneManager.LoadScene("difficultyScene", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void loadGame()
    {
       PlayerData data = DataSave.loadCurrentGame();
        if (data != null)
        {
            Checkpoint.isGameLoaded = true;
            string level = "Nivel " + data.level;
            SceneManager.LoadScene(level, LoadSceneMode.Single);
        }
        
    }
}