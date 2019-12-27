using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escena1 : MonoBehaviour
{
    public float pass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < 210f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 1.2f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Running", true);

        }
        pass += Time.deltaTime;
        if (pass >= 34)
            SceneManager.LoadScene("Nivel 2", LoadSceneMode.Single);
        Debug.Log(pass);
    }
}
