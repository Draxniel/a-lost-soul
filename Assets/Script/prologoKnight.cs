using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prologoKnight : MonoBehaviour
{
    public float pass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pass += Time.deltaTime;
        if (pass > 67)
            Debug.Log("");
    }
}
