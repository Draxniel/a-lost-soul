using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneIconSelection : MonoBehaviour
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
        skin = 2;
        switch (skin)
        {
            case 1:
                gameObject.GetComponent<Animator>().SetBool("Hero1", true);
                gameObject.GetComponent<Animator>().SetBool("Hero2", false);
                break;
            case 2:
                gameObject.GetComponent<Animator>().SetBool("Hero1", false);
                gameObject.GetComponent<Animator>().SetBool("Hero2", true);
                break;
            case 3:
                break;
        }
    }
}
