using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textoCoin : MonoBehaviour
{
    public Player player;
    public Text CoinNumber;
    // Update is called once per frame
    void Update()
    {
        CoinNumber.text = (player.getCoins()).ToString();
    }
}
