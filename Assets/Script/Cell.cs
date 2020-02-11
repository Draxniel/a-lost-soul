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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active) {
            audioSource.clip = sound;
            audioSource.PlayOneShot(audioSource.clip);
            Invoke("vanishObject", 1.2f);
            Invoke("showOpenObject", 1.2f);
        }
    }

    public void vanishObject()
    {
        gameObject.SetActive(false);
    }
    public void showOpenObject()
    {
        if (openCell != null)
        {
            openCell.SetActive(true);

        }
    }
}
