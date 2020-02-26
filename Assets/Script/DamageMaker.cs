using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageMaker : MonoBehaviour
{

    public Player player;
    public int damage;
    private float timer;

    private void Start()
    {
        timer = 0;
        damage = 1;
    }

    private void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        timer += Time.deltaTime;
        if (collision.transform.tag == "Player")
        {
            if (timer >= 0.5f)
            {
                player.TakeDamage(damage);
                timer = 0;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        timer = 0;
    }

}
