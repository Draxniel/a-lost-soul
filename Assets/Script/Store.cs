using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public GameObject tiendaUI, vendedor, Warming;
    public TransactionManager manager;
    public Item[] items;
    public Player player;

    void Start()
    {
        tiendaUI.SetActive(false);
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        if (!vendedor.activeInHierarchy)
            pause();
    }
    public void resume()
    {
        tiendaUI.SetActive(false);
        Warming.SetActive(false);
        Time.timeScale = 1f;
        vendedor.SetActive(true);
    }
    void pause()
    {
        Time.timeScale = 0f;
        tiendaUI.SetActive(true);
    }
    
    public void purchase(Item item)
    {
        if (manager.validateCoins(item))
        {
            player.takeBoost(item);
            player.substractCoins(item.getPrice());
        }
        else
        {
            Warming.SetActive(true);
        }
        
    }
}
