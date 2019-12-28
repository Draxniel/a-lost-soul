using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
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
        if ((gameObject.transform.position.x > 263f) && (pass < 23))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 1.2f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if ((pass < 23))
            gameObject.GetComponent<Animator>().SetBool("Attacking", true);
        else if ((pass > 22) && (pass < 24))
            gameObject.GetComponent<Animator>().SetBool("Attacking", false);
        else if ((gameObject.transform.position.x < 350f))
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 1.2f, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z);
        else if ((pass > 26) && (pass < 32))
            transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
    }

}
