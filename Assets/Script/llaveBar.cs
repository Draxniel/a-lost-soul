using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llaveBar : MonoBehaviour
{
    public GameObject llave, contador;
    // Update is called once per frame
    void Update()
    {
        if (!llave.activeSelf){
            contador.SetActive(true);
        }
    }
}
