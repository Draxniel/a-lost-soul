using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public GameObject tiendaUI, vendedor, Warming, skullText;
    public GameObject[] objects;
    public TransactionManager manager;
    public Item[] items;
    public AudioClip Tienda, skull;
    public AudioClip powerUpSound;
    public Player player;
    public Text CoinNumber;
    public static bool isOpen = false;
    private bool gotSkull;

    bool playAudio = true;

    void Start()
    {
        gotSkull = false;
        if (skullText)
        {
            skullText.SetActive(false);
        }
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

        if (((objects != null) && (gotSkull)) || ((player.manager.getGoldenSkulls() == 6) && (objects != null))){
            foreach (GameObject o in objects)
            {
                o.SetActive(false);
            }
            objects = null;
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

    public void purchaseSkull()
    {
        showText();
        player.substractMaxHealth(3);
        player.takeRawDamage(3);
        DataManager.foundGoldenSkull();
        if (skull)
        {
            SoundController.playOneShot(skull);
        }
        DataManager.saveGame(false);
        foreach (GameObject o in objects){
            o.SetActive(false);
        }
    }
    private void showText()
    {
        if (skullText)
        {
            skullText.SetActive(true);
        }
        Invoke("hideText", 5f);
    }

    private void hideText()
    {
        if (skullText)
        {
            skullText.SetActive(true);
        }
        gameObject.SetActive(false);
    }
}
