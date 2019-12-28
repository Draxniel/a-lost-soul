using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escena3Soul2 : MonoBehaviour
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
        if ((pass < 15) && (gameObject.transform.position.x < 300f))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 1.2f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if ((pass >=36) && (gameObject.transform.position.x > 220f))
            gameObject.transform.position = new Vector3(gameObject.transform.position.x  - 5f, gameObject.transform.position.y, gameObject.transform.position.z);
        Debug.Log(pass);
    }
}
