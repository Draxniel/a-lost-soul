using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public GameObject tiendaUI;
    public TransactionManager manager;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            tiendaUI.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public Item purchase(Item item)
    {
        if (manager.validateCoins(item))
        {
            return item;
        }
        return null;
    }
}
