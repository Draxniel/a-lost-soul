using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public GameObject openCell;
    public bool active;

    private void Start()
    {
        gameObject.SetActive(true);
        active = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active) {
            gameObject.SetActive(false);
            if (openCell != null)
            {
                openCell.SetActive(true);
            }
        }
    }
}
