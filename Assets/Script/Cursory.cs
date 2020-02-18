using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursory : MonoBehaviour
{
    public int number;
    void Start()
    {
        if(number==0)
        Cursor.visible = false;
     
    }

  
    void Update()
    {
        if (number == 0) { 
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = cursorPos;
        }
    }
}
