using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransactionManager : MonoBehaviour
{
    public Player player;

    public bool validateCoins(Item item)
    {
        return (player.getCoins() >= item.getPrice());
    }
}
