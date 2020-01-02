using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public Stat stat;
    private int price;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setPrice (int price)
    {
        this.price = price;
    }

    public int getPrice()
    {
        return this.price;
    }

}
