using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : MonoBehaviour  
{

    public Player player;
    public AudioClip coinSound;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player") {
            gameObject.SetActive(false);
            SoundController.playOneShot(coinSound);
            player.takeCoins(1);
        }
    }    
}
