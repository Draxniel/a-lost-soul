using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soulFade : MonoBehaviour
{
    float pass;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pass += Time.deltaTime;
        if (pass > 16)
        {
            gameObject.GetComponent<Animator>().SetBool("fade", true);
        }
        if (pass > 18)
        {
            gameObject.GetComponent<Animator>().SetBool("idle", true);
        }
    }
}
