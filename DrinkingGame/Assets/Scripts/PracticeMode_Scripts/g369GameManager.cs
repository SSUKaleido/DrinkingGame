using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class g369GameManager : MonoBehaviour
{
    public Image clap;
    public TextMeshProUGUI g369number;
    public Slider TimerSlider;

    public AudioSource EffectAudio;
    [SerializeField] public AudioClip[] EffectAudioClip;

    int number = 1, NumofThree = 0, EnterNum = 0;
    float time = 0.0f;
    bool IsGamestart = false, ClapShowDelay = false;

    public GameObject tilePrefab;
    public Transform backgroundNode;
    public Transform boardNode;
    public Transform tetrominoNode;
    public GameObject gameoverPanel;

    // Start is called before the first frame update
    void Start()
    {
        gameoverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGamestart)
        {
            time += Time.deltaTime;
            TimerSlider.value = time;
            g369number.text = number.ToString();

            if (ClapShowDelay == false)
            {
                g369number.enabled = true;
                clap.enabled = false;
            }

            if (NumofThree != 0 && EnterNum > NumofThree)
                GameOver();

            if (time > 1.0f)
            {
                if (NumofThree != 0 && NumofThree == EnterNum)
                    NextTurn();
                else
                    GameOver();
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                clap.enabled = true;
                g369number.enabled = false;
                ClapShowDelay = true;
                StartCoroutine(ShowClap());
                if (NumofThree != 0)
                    EnterNum++;
                else
                    GameOver();
                EffectAudio.clip = EffectAudioClip[3];
                EffectAudio.Play();
            }

            if (Input.GetKeyDown(KeyCode.Space) && NumofThree == 0) {
                EffectAudio.clip = EffectAudioClip[7];
                EffectAudio.Play();
                NextTurn();
            }
            else if (Input.GetKeyDown(KeyCode.Space) && NumofThree != 0)
                GameOver();
        }
    }

    void NextTurn()
    {
        time = 0.0f;
        number++;
        NumofThree = 0;
        EnterNum = 0;

        for (int NowNum = number; NowNum > 0; NowNum /= 10)
        {
            if (NowNum % 10 == 3 || NowNum % 10 == 6 || NowNum % 10 == 9)
                NumofThree++;
        }
    }

    IEnumerator ShowClap()
    {
        yield return new WaitForSeconds(0.3f);
        ClapShowDelay = false;
    }

    public void GameStart()
    {
        IsGamestart = true;
        ClapShowDelay = false;
        gameoverPanel.SetActive(false);
        g369number.enabled = true;
        clap.enabled = false;
        time = 0.0f;
        number = 1;
        NumofThree = 0;
        EnterNum = 0;
    }

    void GameOver()
    {
        IsGamestart = false;
        gameoverPanel.SetActive(true);
    }
}


