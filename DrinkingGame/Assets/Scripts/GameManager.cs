using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject CoverImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPracticeMode()
    {
        CoverImage.SetActive(false);
    }

    public void LoadRealMode()
    {
        SceneManager.LoadScene("RealMode_Scene");
    }

    public void Conclusion()
    {
        Application.Quit();
    }
}
