using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playersoul : MonoBehaviour
{
    float pass;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pass += Time.deltaTime;
        if ((gameObject.transform.position.y < 150) && (pass > 5)){

        }
    }
}
