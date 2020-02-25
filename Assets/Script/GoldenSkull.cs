using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenSkull : MonoBehaviour
{
    public bool found = false;
    public AudioClip sound;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        found = false;
        text.SetActive(false);
        gameObject.GetComponent<Renderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            showText();
            gameObject.GetComponent<Renderer>().enabled = false;
            DataManager.foundGoldenSkull();
            SoundController.playOneShot(sound);
        }
    }

    private void showText()
    {
        text.SetActive(true);
        Invoke("hideText", 5f);
    }

    private void hideText()
    {
        text.SetActive(false);
        gameObject.SetActive(false);
    }
}
