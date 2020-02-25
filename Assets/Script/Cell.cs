using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public GameObject openCell;
    public bool active;
    public AudioClip sound;

    private void Start()
    {
        gameObject.SetActive(true);
        active = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (active)
            {
                SoundController.playOneShot(sound);
                gameObject.SetActive(false);
                if (openCell != null)
                {
                    openCell.SetActive(true);

                }
            }
        }
    }
}
