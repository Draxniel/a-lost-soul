using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcObject : MonoBehaviour
{
    public Cell toAct;
    public bool lever, active;
    public GameObject[] objects;

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
            if (lever)
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

    public bool AllObjectsActivated()
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

    public void ActivateCell()
    {
        if ((toAct != null) && AllObjectsActivated())
        {
            toAct.active = true;
        }
    }
}
