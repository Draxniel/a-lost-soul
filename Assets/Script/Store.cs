using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public GameObject tiendaUI, vendedor, Warming;
    public TransactionManager manager;
    public Item[] items;
    public AudioClip Tienda;
    public AudioClip powerUpSound;
    public Player player;
    public Text CoinNumber;
    public static bool isOpen = false;

    bool playAudio = true;

    void Start()
    {
        tiendaUI.SetActive(false);
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        CoinNumber.text = (player.getCoins()).ToString();
        if (!vendedor.activeInHierarchy)
        {
            pause();
            if (playAudio)
            {
                SoundController.playOneShot(Tienda);
                playAudio = false;
            }
        }
        if ((Input.GetKeyDown(KeyCode.Escape)) && (isOpen))
        {
            resume();
        }
    }
    public void resume()
    {
        Cursor.visible = false;
        isOpen = false;
        tiendaUI.SetActive(false);
        Warming.SetActive(false);
        Time.timeScale = 1f;
        vendedor.SetActive(true);
        playAudio = true;
        PauseMenu.canPause = true;
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
            SoundController.setPitch(1);
            SoundController.setVolume(1);
            SoundController.playOneShot(powerUpSound);
        }
        else
        {
            Warming.SetActive(true);
        }
        
    }
}
