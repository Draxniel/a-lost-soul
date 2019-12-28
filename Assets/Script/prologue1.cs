using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class prologue1 : MonoBehaviour
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
        if (pass >= 175)
            SceneManager.LoadScene("prólogoPt2", LoadSceneMode.Single);
        Debug.Log(pass);
    }
}
