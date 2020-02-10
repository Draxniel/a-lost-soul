using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul4 : MonoBehaviour
{
    float pass;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pass += Time.deltaTime;
        if (pass > 28)
        {
            gameObject.GetComponent<Animator>().SetBool("fade", true);
        }
        if (pass > 30)
        {
            gameObject.GetComponent<Animator>().SetBool("idle", true);
        }
    }
}
