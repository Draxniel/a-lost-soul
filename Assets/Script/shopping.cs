using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopping : MonoBehaviour
{
    public GameObject tiendaUI, vendedor;

    void Start()
    {
        tiendaUI.SetActive(false);
        Time.timeScale = 1f;
    }
    // Update is called once per frame
    void Update()
    {
        if (!vendedor.activeInHierarchy)
            pause();
    }
    public void resume()
    {
        tiendaUI.SetActive(false);
        Time.timeScale = 1f;
        vendedor.SetActive(true);
    }
    void pause()
    {
        Time.timeScale = 0f;
        tiendaUI.SetActive(true);
    }
}
