using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerSoulController : MonoBehaviour
{
    public float pass;
    public bool end;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pass += Time.deltaTime;
        Debug.Log(pass);
        if ((gameObject.transform.position.y < 165) && (pass > 5) && (pass < 8))
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1.2f, gameObject.transform.position.z);
        }
        else if ((gameObject.transform.position.x > 135) && (pass > 8))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x - 1.2f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else if ((gameObject.transform.position.y > 94) && (pass > 8))
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1.2f, gameObject.transform.position.z);
        }
        else if ((pass > 10) && (pass < 69))
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            end = true;
        }
        else if ((pass > 70) && (end))
        {
            SceneManager.LoadScene("Menu secundario", LoadSceneMode.Single);
            DataManager.saveGame();
            DataSave.saveCurrentGame();
        }
    }
}
