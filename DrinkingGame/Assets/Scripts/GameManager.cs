using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Canvas StartMenu;
    public Canvas PracticeMode_SelectMenu;
    public Canvas PracticeMode_HangeulGame;
    public Canvas PracticeMode_BaskinGame;
    public Canvas PracticeMode_RabbitGame;
    public Canvas PracticeMode_FruitsGame;
    public Canvas PracticeMode_369Game;

    public CanvasGroup StartMenu_Group;
    public CanvasGroup PracticeMode_SelectMenu_Group;
    public CanvasGroup PracticeMode_HangeulGame_Group;
    public CanvasGroup PracticeMode_BaskinGame_Group;
    public CanvasGroup PracticeMode_RabbitGame_Group;
    public CanvasGroup PracticeMode_FruitsGame_Group;
    public CanvasGroup PracticeMode_369Game_Group;

    public GameObject ExplainMenu;

    public AudioSource EffectAudio;
    [SerializeField] public AudioClip[] EffectAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        StartMenu.enabled = true;
        PracticeMode_SelectMenu.enabled = false;
        PracticeMode_SelectMenu_Group.interactable = false;
        PracticeMode_HangeulGame.enabled = false;
        PracticeMode_HangeulGame_Group.interactable = false;
        PracticeMode_BaskinGame.enabled = false;
        PracticeMode_BaskinGame_Group.interactable = false;
        PracticeMode_RabbitGame.enabled = false;
        PracticeMode_RabbitGame_Group.interactable = false;
        PracticeMode_FruitsGame.enabled = false;
        PracticeMode_FruitsGame_Group.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadPracticeMode() {
        PracticeMode_SelectMenu.enabled = true;
        PracticeMode_SelectMenu_Group.interactable = true;
        ExplainMenu.SetActive(false);
        StartMenu.enabled = false;
        EffectAudio.clip = EffectAudioClip[0];
        EffectAudio.Play();
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

        EffectAudio.clip = EffectAudioClip[0];
        EffectAudio.Play();
    }

    public void LoadPracticeGame_Hangeul() {
        PracticeMode_HangeulGame.enabled = true;
        PracticeMode_HangeulGame_Group.interactable = true;
        PracticeMode_SelectMenu.enabled = false;
        PracticeMode_SelectMenu_Group.interactable = false;
        EffectAudio.clip = EffectAudioClip[0];
        EffectAudio.Play();
    }

    public void LoadPracticeGame_Baskin() {
        PracticeMode_BaskinGame.enabled = true;
        PracticeMode_BaskinGame_Group.interactable = true;
        PracticeMode_SelectMenu.enabled = false;
        PracticeMode_SelectMenu_Group.interactable = false;
        EffectAudio.clip = EffectAudioClip[0];
        EffectAudio.Play();
    }

    public void LoadPracticeGame_Rabbit() {
        PracticeMode_RabbitGame.enabled = true;
        PracticeMode_RabbitGame_Group.interactable = true;
        PracticeMode_SelectMenu.enabled = false;
        PracticeMode_SelectMenu_Group.interactable = false;
        EffectAudio.clip = EffectAudioClip[0];
        EffectAudio.Play();
    }

    public void LoadPracticeGame_Fruits() {
        PracticeMode_FruitsGame.enabled = true;
        PracticeMode_FruitsGame_Group.interactable = true;
        PracticeMode_SelectMenu.enabled = false;
        PracticeMode_SelectMenu_Group.interactable = false;
        EffectAudio.clip = EffectAudioClip[0];
        EffectAudio.Play();
    }

    public void LoadPracticeGame_369() {
        PracticeMode_369Game.enabled = true;
        PracticeMode_369Game_Group.interactable = true;
        PracticeMode_SelectMenu.enabled = false;
        PracticeMode_SelectMenu_Group.interactable = false;
        EffectAudio.clip = EffectAudioClip[0];
        EffectAudio.Play();
    }

    public void UnloadPracticeGame_Hangeul() {
        PracticeMode_SelectMenu.enabled = true;
        PracticeMode_SelectMenu_Group.interactable = true;
        PracticeMode_HangeulGame.enabled = false;
        PracticeMode_HangeulGame_Group.interactable = false;
        EffectAudio.clip = EffectAudioClip[0];
        EffectAudio.Play();
    }

    public void UnloadPracticeGame_Baskin() {
        PracticeMode_SelectMenu.enabled = true;
        PracticeMode_SelectMenu_Group.interactable = true;
        PracticeMode_BaskinGame.enabled = false;
        PracticeMode_BaskinGame_Group.interactable = false;
        EffectAudio.clip = EffectAudioClip[0];
        EffectAudio.Play();
    }

    public void UnloadPracticeGame_Rabbit() {
        PracticeMode_SelectMenu.enabled = true;
        PracticeMode_SelectMenu_Group.interactable = true;
        PracticeMode_RabbitGame.enabled = false;
        PracticeMode_RabbitGame_Group.interactable = false;
        EffectAudio.clip = EffectAudioClip[0];
        EffectAudio.Play();
    }

    public void UnloadPracticeGame_Fruits() {
        PracticeMode_SelectMenu.enabled = true;
        PracticeMode_SelectMenu_Group.interactable = true;
        PracticeMode_FruitsGame.enabled = false;
        PracticeMode_FruitsGame_Group.interactable = false;
        EffectAudio.clip = EffectAudioClip[0];
        EffectAudio.Play();
    }

    public void UnloadPracticeGame_369() {
        PracticeMode_SelectMenu.enabled = true;
        PracticeMode_SelectMenu_Group.interactable = true;
        PracticeMode_369Game.enabled = false;
        PracticeMode_369Game_Group.interactable = false;
        EffectAudio.clip = EffectAudioClip[0];
        EffectAudio.Play();
    }

    public void Conclusion() {
        Application.Quit();
    }
}