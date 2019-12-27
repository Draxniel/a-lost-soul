using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMaker : MonoBehaviour
{

    public Player player;
    public int damage;
    private float timer;
    private bool isIn;

    private void Start()
    {
        timer = 0;
        isIn = false;
        damage = 1;
    }

    private void Update()
    {
        if (isIn)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 0.5f)
        {
            player.TakeDamage(damage);
            timer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.TakeDamage(damage);
        isIn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isIn = false;
        timer = 0;
    }

}
