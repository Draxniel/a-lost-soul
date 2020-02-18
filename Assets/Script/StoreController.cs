using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreController : MonoBehaviour
{
    public GameObject tiendaUI;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Cursor.visible = true;
            tiendaUI.SetActive(true);
            gameObject.SetActive(false);
            PauseMenu.canPause = false;
            Store.isOpen = true;
        }
    }
}
