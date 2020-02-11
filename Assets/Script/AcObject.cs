﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcObject : MonoBehaviour
{
    public Cell toAct;
    public bool lever, active;
    public GameObject[] objects;    //Una referencia a los demás objetos en el nivel
    public AudioClip sound;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
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
                audioSource.clip = sound;
                audioSource.volume = 1f;
                audioSource.PlayOneShot(audioSource.clip);
            }
            else
            {
                audioSource.clip = sound;
                audioSource.PlayOneShot(audioSource.clip);
                Invoke("vanishObject", 0.6f);
                active = true;
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
    public void vanishObject()
    {
        gameObject.SetActive(false);
    }

    public void ActivateCell()  //Activa la celda que contiene el coleccionable
    {
        if ((toAct != null) && AllObjectsActivated())
        {
            toAct.active = true;
        }
    }

}
