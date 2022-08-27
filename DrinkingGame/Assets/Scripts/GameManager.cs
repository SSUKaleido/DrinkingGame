using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas StartMenu;
    public Canvas PracticeMode_SelectMenu;
    public Canvas PracticeMode_TrainGame;
    public Canvas PracticeMode_BaskinGame;
    public Canvas PracticeMode_RabbitGame;
    public Canvas PracticeMode_FruitsGame;

    public CanvasGroup StartMenu_Group;
    public CanvasGroup PracticeMode_SelectMenu_Group;
    public CanvasGroup PracticeMode_TrainGame_Group;
    public CanvasGroup PracticeMode_BaskinGame_Group;
    public CanvasGroup PracticeMode_RabbitGame_Group;
    public CanvasGroup PracticeMode_FruitsGame_Group;

    // Start is called before the first frame update
    void Start()
    {
        StartMenu.enabled = true;
        PracticeMode_SelectMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPracticeMode() {
        PracticeMode_SelectMenu.enabled = true;
        PracticeMode_SelectMenu_Group.interactable = true;
        StartMenu.enabled = false;
    }

    public void LoadRealMode() {
        SceneManager.LoadScene("RealMode_Scene");
    }

    public void LoadStartMenu() {
        if(SceneManager.GetActiveScene().name == "StartScene") {
            StartMenu.enabled = true;
            StartMenu_Group.interactable = true;
            PracticeMode_SelectMenu.enabled = false;
        }
        else if (SceneManager.GetActiveScene().name == "RealMode_Scene") {
            SceneManager.LoadScene("StartScene");
        }
    }

    public void LoadPracticeGame_Train() {
        PracticeMode_TrainGame.enabled = true;
        PracticeMode_TrainGame_Group.interactable = true;
        PracticeMode_SelectMenu.enabled = false;
    }

    public void LoadPracticeGame_Baskin() {
        PracticeMode_BaskinGame.enabled = true;
        PracticeMode_BaskinGame_Group.interactable = true;
        PracticeMode_SelectMenu.enabled = false;
    }

    public void LoadPracticeGame_Rabbit() {
        PracticeMode_RabbitGame.enabled = true;
        PracticeMode_RabbitGame_Group.interactable = true;
        PracticeMode_SelectMenu.enabled = false;
    }

    public void LoadPracticeGame_Fruits() {
        PracticeMode_FruitsGame.enabled = true;
        PracticeMode_FruitsGame_Group.interactable = true;
        PracticeMode_SelectMenu.enabled = false;
    }

    public void Conclusion() {
        Application.Quit();
    }
}
