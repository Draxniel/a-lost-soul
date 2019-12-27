using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiendita : MonoBehaviour
{
    public GameObject tiendaUI;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            tiendaUI.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
