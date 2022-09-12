using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BaskinGameManager : MonoBehaviour
{
    public Slider TimerSlider;
    public Image Players_Icecream1, Players_Icecream2, Players_Icecream3;
    public Image Computers_Icecream1, Computers_Icecream2, Computers_Icecream3;
    public TextMeshProUGUI NumberText, GuideText;

    int GameMode = 0, IcecreamSlot = 0, BaskinNum = 0;
    float time = 0.0f, delay = 0.0f;

    // Game over
    public GameObject tilePrefab;
    public Transform backgroundNode;
    public Transform boardNode;
    public Transform tetrominoNode;
    public GameObject gameoverPanel;

    // Start is called before the first frame update
    void Start()
    {
        Players_Icecream1.enabled = false;
        Players_Icecream2.enabled = false;
        Players_Icecream3.enabled = false;
        Computers_Icecream1.enabled = false;
        Computers_Icecream2.enabled = false;
        Computers_Icecream3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMode != 0) {
            time += Time.deltaTime;
            TimerSlider.value = time;
            NumberText.text = BaskinNum.ToString();

            if (time > 1.0f) {
                time = 0.0f;
                if (GameMode == 1 && IcecreamSlot == 0)
                    GameOver(true);
                else if (GameMode == 1) {
                    GuideText.text = "상대방의 차례";
                    GameMode = 2;
                    Computers_Icecream1.enabled = false;
                    Computers_Icecream2.enabled = false;
                    Computers_Icecream3.enabled = false;
                    IcecreamSlot = Random.Range(1, 4);
                    delay = Random.Range(0.0f, 1.0f);
                }
                else {
                    GuideText.text = "당신의 차례";
                    GameMode = 1;
                    Players_Icecream1.enabled = false;
                    Players_Icecream2.enabled = false;
                    Players_Icecream3.enabled = false;
                    IcecreamSlot = 0;
                }
            }

            if (Input.GetKeyDown(KeyCode.Return) && GameMode == 1 && IcecreamSlot < 3)
                AddIcecreamNum();

            if (BaskinNum >= 31)
                GameOver(false);

            if (GameMode == 2)
                ComputerPlay();
        }
    }

    public void GameStart_Baskin() {
        GameMode = 1;
        time = 0.0f;
        delay = 0.0f;
        BaskinNum = 0;
        IcecreamSlot = 0;
        GuideText.text = "Enter키를 눌러 숫자를 올릴 수 있습니다";
        Players_Icecream1.enabled = false;
        Players_Icecream2.enabled = false;
        Players_Icecream3.enabled = false;
        Computers_Icecream1.enabled = false;
        Computers_Icecream2.enabled = false;
        Computers_Icecream3.enabled = false;
    }

    public void AddButtonDown() {
        if (GameMode == 1 && IcecreamSlot < 3)
            AddIcecreamNum();
    }

    void AddIcecreamNum() {
        IcecreamSlot++; BaskinNum++;
        TrunOnIcon(true);
    }

    void GameOver(bool PlayerMiss) {
        if (PlayerMiss == true)
            GuideText.text = "타이밍을 놓쳤습니다!";
        else if (GameMode == 2)
            GuideText.text = "당신의 승리입니다!";
        else
            GuideText.text = "당신의 패배입니다";
        GameMode = 0;
    }

    void ComputerPlay() {
        delay -= Time.deltaTime;

        if (delay <= 0 && IcecreamSlot > 0) {
            delay = Random.Range(0.0f, 1.0f - time);
            TrunOnIcon(false);
            IcecreamSlot--;
            BaskinNum++;
        }
    }

    void TrunOnIcon(bool IsPlayersIcon) {
        if (IsPlayersIcon == true && IcecreamSlot == 1)
            Players_Icecream1.enabled = true;
        else if (IsPlayersIcon == true && IcecreamSlot == 2)
            Players_Icecream2.enabled = true;
        else if (IsPlayersIcon == true && IcecreamSlot == 3)
            Players_Icecream3.enabled = true;
        else if (IsPlayersIcon == false && Computers_Icecream1.enabled == false)
            Computers_Icecream1.enabled = true;
        else if (IsPlayersIcon == false && Computers_Icecream2.enabled == false)
            Computers_Icecream2.enabled = true;
        else if (IsPlayersIcon == false && Computers_Icecream3.enabled == false)
            Computers_Icecream3.enabled = true;
    }
}