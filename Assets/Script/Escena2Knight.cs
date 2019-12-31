using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escena2Knight : MonoBehaviour
{
    public int skin;
    public DataManager manager;
    // Start is called before the first frame update
    void Start()
    {
        skin = manager.getSkinNumber();
    }

    // Update is called once per frame
    void Update()
    {
        skin = manager.getSkinNumber();
        switch (skin)
        {
            case 1:
                GetComponent<Animator>().SetBool("Hero2", false);
                break;
            case 2:
                GetComponent<Animator>().SetBool("Hero2", true);
                break;
            case 3:
                break;
        }
        if (gameObject.transform.position.x < 210f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 1.2f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Running", true);

        }
    }
}
