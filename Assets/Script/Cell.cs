using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public GameObject openCell;
    public bool active;
    public AudioClip sound;
    public AudioSource audioSource;
    public float time;
    private bool isTouched = false;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        gameObject.SetActive(true);
        active = false;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if ((time > 2) && (active) && (isTouched))
        {
            gameObject.SetActive(false);
        }
        if (openCell != null)
        {
            openCell.SetActive(true);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active) { 
            audioSource.clip = sound;
            audioSource.PlayOneShot(audioSource.clip);
            time = 0;
            isTouched = true;
        }
    }
}
