using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escena3Knight : MonoBehaviour

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
        if (gameObject.transform.position.x < 120f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 1.2f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if ( (pass < 30) && (gameObject.transform.position.x >= 120f))
        {
            gameObject.GetComponent<Animator>().SetBool("Running", true);

        }
        else if ((pass >= 60) && (gameObject.transform.position.x < 270f))
        {
            gameObject.GetComponent<Animator>().SetBool("Running", false);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 1.2f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else
            gameObject.GetComponent<Animator>().SetBool("Running", true);
        if (pass >= 67)
            SceneManager.LoadScene("Nivel 4", LoadSceneMode.Single);

    }
}
