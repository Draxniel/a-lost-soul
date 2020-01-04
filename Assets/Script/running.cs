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

    void Start()
    {
        skin = manager.getSkinNumber();
        GetComponent<AudioSource>().PlayDelayed(4f); // Activa la música después de 4 seg...
    }

    // Update is called once per frame
    void Update()
    {
        skin = manager.getSkinNumber();
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
    }

    public void play()
    {
        SceneManager.LoadScene("difficultyScene", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}