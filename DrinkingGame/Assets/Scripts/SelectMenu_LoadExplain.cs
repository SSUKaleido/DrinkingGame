using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMenu_LoadExplain : MonoBehaviour
{
    public GameObject ExplainMenu;

    public AudioSource EffectAudio;
    [SerializeField] public AudioClip[] EffectAudioClip;

    public void LoadExplainWindow() {
        EffectAudio.clip = EffectAudioClip[0];
        EffectAudio.Play();
        ExplainMenu.SetActive(true);
    }
}