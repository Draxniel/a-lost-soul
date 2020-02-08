using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : MonoBehaviour
{
    public GameObject tiendaUI;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((Input.GetKeyDown(KeyCode.E)))
        {
            Debug.Log("ESTA ENTRANDO");
            PauseMenu.canPause = false;
            tiendaUI.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
