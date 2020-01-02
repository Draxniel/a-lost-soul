using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectOption : MonoBehaviour
{
    public DataManager manager;
    public GameObject player1;
    private void OnMouseDown()
    {
        
        if (Input.GetMouseButtonDown(0)) {
            if (player1.activeSelf)
                manager.setSkinNumber(1);
            else
                manager.setSkinNumber(2);
            SceneManager.LoadScene("prólogoPt2", LoadSceneMode.Single);
        }
    }
}
