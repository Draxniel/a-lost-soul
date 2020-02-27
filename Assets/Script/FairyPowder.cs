using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyPowder : MonoBehaviour
{
    public Stat health;
    public Stat strenght;
    public int price, value;
    // Start is called before the first frame update
    public Stat getStat1()
    {
        return strenght;
    }
    public Stat getStat2()
    {
        return health;
    }
    public int getPrice()
    {
        return this.price;
    }

    public int getValue()
    {
        return value;
    }
}
