using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul3 : MonoBehaviour
{
    float pass;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pass += Time.deltaTime;
        if (pass > 24)
        {
            gameObject.GetComponent<Animator>().SetBool("fade", true);
        }
        if (pass > 26)
        {
            gameObject.GetComponent<Animator>().SetBool("idle", true);
        }
    }
}
