using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Music : MonoBehaviour
{
    public bool play;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
       play = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (play)
        {
            Camera.main.GetComponent<AudioSource>().Stop();
            Camera.main.GetComponent<AudioSource>().clip = clip;
            Camera.main.GetComponent<AudioSource>().Play();
            play = false;
        }
        ;
    }
}
