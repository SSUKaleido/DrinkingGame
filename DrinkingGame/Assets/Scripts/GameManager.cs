using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Start_PracticeGame() {
        SceneManager.LoadScene("PracticeMode_Scene");
    }

    public void Start_RealGame() {
        SceneManager.LoadScene("RealMode_Scene");
    }
}
