using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escena3Soul3B : MonoBehaviour
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
        if ((pass < 15) && (gameObject.transform.position.x < 335f))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 2.4f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if ((pass >= 36) && (gameObject.transform.position.x > 130f))
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 8f, gameObject.transform.position.y - 3.7f, gameObject.transform.position.z);

    }
}
