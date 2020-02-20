using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knight : MonoBehaviour

{
    public int skin;
    public DataManager manager;
    public float pass;
    // Start is called before the first frame update
    void Start()
    {
        skin = manager.getSkinNumber();
    }

    // Update is called once per frame
    void FixedUpdate()
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
        pass += Time.deltaTime;
        if (gameObject.transform.position.x < 120f)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 1.2f, gameObject.transform.position.y, gameObject.transform.position.z);
        }
        else
            gameObject.GetComponent<Animator>().SetBool("Running", true);
        if (pass > 58) SceneManager.LoadScene("Nivel 5", LoadSceneMode.Single);



    }
}
