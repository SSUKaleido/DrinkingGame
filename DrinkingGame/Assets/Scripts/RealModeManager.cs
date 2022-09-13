using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RealModeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "RealMode_Scene")
            SceneManager.LoadScene("StartScene");
    }
}
