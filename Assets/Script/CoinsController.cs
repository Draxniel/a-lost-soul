using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsController : MonoBehaviour  
{

    public Player player;
    public AudioSource coinSource;
    public AudioClip coinSound;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        gameObject.AddComponent<AudioSource>();
        coinSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        coinSource.PlayOneShot(coinSound);
        Invoke("vanishCoin", 0.35f);
        player.takeCoins(1);
    }

    public void vanishCoin()
    {
        gameObject.SetActive(false);
    }

    
}
