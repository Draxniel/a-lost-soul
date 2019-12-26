using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escena2Soul : MonoBehaviour
{
    public float pass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((gameObject.transform.position.y > 105) && (gameObject.transform.position.x < 110))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1.2f, gameObject.transform.position.z);
        }
        if((gameObject.transform.position.y < 150) && (gameObject.transform.position.x < 300))
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 1.2f, gameObject.transform.position.y + 0.01f, gameObject.transform.position.z);
        pass += Time.deltaTime;
        if (pass >= 48)
            SceneManager.LoadScene("Nivel 3", LoadSceneMode.Single);
    }
}
