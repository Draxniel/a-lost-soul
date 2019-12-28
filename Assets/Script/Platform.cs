using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float positionx,positiony;
    public bool direccion = true;
    public int x,sentido;//sentido 1:izquierda; 2:abajo; 3:derecha & 4:arriba
    // Start is called before the first frame update
    void Start()
    {
        positionx = transform.position.x;
        positiony = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        switch (sentido) {
            case 1:
            if (direccion){
               transform.Translate(-1f * Time.timeScale, 0, 0);
               if (transform.position.x == positionx - x)
                direccion = false;
            }
            else {
                transform.Translate(1f * Time.timeScale, 0, 0);
                if (transform.position.x == positionx)
                direccion = true;
            }
                break;
            case 2:
            if (direccion){
               transform.Translate(0, -1f * Time.timeScale, 0);
               if (transform.position.y == positiony - x)
                direccion = false;
            }
            else{
               transform.Translate(0, 1f * Time.timeScale, 0);
               if (transform.position.y == positiony)
                direccion = true;
            }
                break;
            case 3:
                if (direccion)
                {
                    transform.Translate(1f * Time.timeScale, 0, 0);
                    if (transform.position.x == positionx + x)
                        direccion = false;
                }
                else
                {
                    transform.Translate(-1f * Time.timeScale, 0, 0);
                    if (transform.position.x == positionx)
                        direccion = true;
                }
                break;
            case 4:
                if (direccion)
                {
                    transform.Translate(0, 1f * Time.timeScale, 0);
                    if (transform.position.y == positiony + x)
                        direccion = false;
                }
                else
                {
                    transform.Translate(0, -1f * Time.timeScale, 0);
                    if (transform.position.y == positiony)
                        direccion = true;
                }
                break;
        }
    }
}
