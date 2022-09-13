using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{

    private AudioSource BackgroundAudio;

    // Start is called before the first frame update
    void Start()
    {
        BackgroundAudio = GetComponent<AudioSource>();
    }

    public void MusicOnOff() {
        if (BackgroundAudio.mute)
            BackgroundAudio.mute = false;
        else
            BackgroundAudio.mute = true;
    }
}
