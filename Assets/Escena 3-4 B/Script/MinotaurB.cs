using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x > 350f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.8f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Arrive", true);

        }
    }
}
