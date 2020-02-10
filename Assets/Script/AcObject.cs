using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcObject : MonoBehaviour
{
    public Cell toAct;
    public bool lever, active;
    public GameObject[] objects;    //Una referencia a los demás objetos en el nivel

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        active = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!active)
        {
            if (lever)  //Validación para que se invierta el sprite de la palanca y no desaparezca
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                active = true;
            }
            else
            {
                active = true;
                gameObject.SetActive(false);
            }
        }
        ActivateCell();
    }

    public bool AllObjectsActivated()   //Valida que todos lo demás objetos en el nivel (en caso de haberlos) están desactivados
    {
        if (objects != null)
        {
            foreach (GameObject g in objects)
            {
                if (g.activeInHierarchy)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void ActivateCell()  //Activa la celda que contiene el coleccionable
    {
        if ((toAct != null) && AllObjectsActivated())
        {
            toAct.active = true;
        }
    }

}
