using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skip : MonoBehaviour
{
    public string escenas;
        public void skipscene() {
            SceneManager.LoadScene(escenas, LoadSceneMode.Single);
        }
    
}
