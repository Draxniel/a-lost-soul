using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulControl : MonoBehaviour
{

    public GameObject door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
        door.gameObject.SetActive(true);
    }

    //Aqui dentro debe ir la llamada para que aparezca el final del nivel

}
