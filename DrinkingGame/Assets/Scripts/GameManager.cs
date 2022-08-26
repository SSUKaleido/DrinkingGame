using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject CoverImage;
    public GameObject PracticeMode_SelectMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPracticeMode() {
        PracticeMode_SelectMenu.SetActive(true);
        CoverImage.SetActive(false);
    }

    public void LoadRealMode() {
        SceneManager.LoadScene("RealMode_Scene");
    }

    public void LoadStartMenu() {
        if(SceneManager.GetActiveScene().name == "StartScene") {
            CoverImage.SetActive(true);
            PracticeMode_SelectMenu.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "RealMode_Scene") {
            SceneManager.LoadScene("StartScene");
        }
    }

    public void Conclusion() {
        Application.Quit();
    }
}
