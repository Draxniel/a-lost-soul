using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prev : MonoBehaviour
{
    public GameObject player1, player2;
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (player1.activeSelf)
            {
                player1.SetActive(false);
                player2.SetActive(true);
            }
            else
            {
                player1.SetActive(true);
                player2.SetActive(false);
            }
        }
    }
}
    