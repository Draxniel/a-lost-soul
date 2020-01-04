using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransactionManager : MonoBehaviour
{
    public Player player;

    public bool ValidateCoins(Item item)
    {
        return (player.getCoins() >= item.getPrice());
    }

    public void BuyAndBoost(Item item)
    {
        player.substractCoins(item.getPrice());
        player.takeBoost(item);
    }
}
