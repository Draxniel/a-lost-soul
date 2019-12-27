using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoulPrologo : MonoBehaviour
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
        if ((gameObject.transform.position.y > 105) && (gameObject.transform.position.x > 188) && (pass < 5))
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 2.4f, gameObject.transform.position.y - 1.2f, gameObject.transform.position.z);
        else if ((pass > 7) && (pass < 12))
        {
            if (gameObject.transform.position.x < 220)
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + 2.4f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if ((pass > 12) && (pass < 20))
        {
            if ((gameObject.transform.position.x > 188))
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - 1f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if ((pass > 64) && (pass < 72))
        {
            if ((gameObject.transform.position.x > 121))
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y, gameObject.transform.position.z);
            else
                gameObject.GetComponent<Renderer>().enabled = false;
        }
        else if ((pass >= 174))
            SceneManager.LoadScene("Nivel 1", LoadSceneMode.Single);
    }
}
