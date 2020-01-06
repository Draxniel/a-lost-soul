using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public GameObject tiendaUI, vendedor, Warming;
    public TransactionManager manager;
    public Item[] items;
    public AudioClip[] sellerAudioArray;
    public AudioClip powerUpSound;
    public AudioSource sellerSource;
           
    bool playAudio = true;

    void Start()
    {
        
        sellerSource = gameObject.AddComponent<AudioSource>();
        tiendaUI.SetActive(false);
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {

        if (!vendedor.activeInHierarchy)
        {
            pause();
            if (playAudio)
            {
                sellerSource.clip = sellerAudioArray[Random.Range(0, sellerAudioArray.Length)];
                sellerSource.PlayOneShot(sellerSource.clip);
                playAudio = false;
            }

        }
    }
    public void resume()
    {
        tiendaUI.SetActive(false);
        Warming.SetActive(false);
        Time.timeScale = 1f;
        vendedor.SetActive(true);
        playAudio = true;
    }
    void pause()
    {  
        Time.timeScale = 0f;
        tiendaUI.SetActive(true);
    }
    
    public void purchase(Item item)
    {
        if (manager.ValidateCoins(item))
        {
            manager.BuyAndBoost(item);
            sellerSource.PlayOneShot(powerUpSound);
        }
        else
        {
            Warming.SetActive(true);
        }
        
    }
}
