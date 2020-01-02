using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public Stat stat;
    public int price, value;

    public int getPrice()
    {
        return this.price;
    }

    public int getValue()
    {
        return value;
    }

    public Stat getStat()
    {
        return stat;
    }

}