using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RabbitGameManager : MonoBehaviour
{
    public ImageLineRenderer ArrowLine;
    public Image RecurrsiveArrowLine;
    public Image[] ExclamationMark;
    public RectTransform[] Person;
    public Slider TimerSlider;

    Vector3[] PersonPoint = new Vector3[8];
    Vector3 MousePosition;

    int RandomNum = 0, BeforeNum = 0, TurnNum = 0;
    float time = 0.0f, TimerUpper = 0.5f;
    bool IsGameStart = false, IsPlayerLeftMove = true, IsPlayerRightMove = true, IsPlayerChoiceTurn = false;

    // Start is called before the first frame update
    void Start()
    {
        PersonPoint[0] = new Vector3(960, 380, 0);
        PersonPoint[1] = new Vector3(1063.137f, 416.8629f, 0);
        PersonPoint[2] = new Vector3(836.8629f, 416.8629f, 0);
        PersonPoint[3] = new Vector3(1120, 540, 0);
        PersonPoint[4] = new Vector3(1063.137f, 643.1371f, 0);
        PersonPoint[5] = new Vector3(960, 700, 0);
        PersonPoint[6] = new Vector3(836.8629f, 643.1371f, 0);
        PersonPoint[7] = new Vector3(800, 540, 0);

        ExclamationMark[0].enabled = false;
        ExclamationMark[1].enabled = false;
        ExclamationMark[2].enabled = false;
        ExclamationMark[3].enabled = false;
        ExclamationMark[4].enabled = false;
        ExclamationMark[5].enabled = false;
        ExclamationMark[6].enabled = false;
        ExclamationMark[7].enabled = false;

        RecurrsiveArrowLine.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameStart == true && IsPlayerChoiceTurn == false) {
            time += Time.deltaTime;
            if (time > TimerUpper) {
                if(IsPlayerLeftMove == false || IsPlayerRightMove == false) {
                    GameOver(0);
                }

                time = 0.0f;
                TurnNum++;
                if (ArrowLine.PointB != PersonPoint[0])
                    NextTurn_Computer();
                else
                    ChoiceTurn_Player();

                if (TimerUpper == 0.5f) {
                    TimerUpper = 2.0f;
                    if (TurnNum > 20 && Random.Range(0.0f, 100.0f) < TurnNum * 0.1f)
                        GameWin();
                    else if (RandomNum != 0)
                        Shake_ComputerPerson();
                }
                else if (TimerUpper == 2.0f)
                    TimerUpper = 0.5f;
            }

            TimerSlider.value = (time / TimerUpper);

            if (Input.GetKeyDown(KeyCode.LeftArrow))
                LeftShake_PlayerPerson();
            if (Input.GetKeyDown(KeyCode.RightArrow))
                RightShake_PlayerPerson();
        }
        
        else if (IsGameStart == true && IsPlayerChoiceTurn == true) {
            MousePosition = Input.mousePosition;
            ArrowLine.PointB = MousePosition;

        }
    }

    public void GameStart() {
        time = 0.0f;
        TimerUpper = 2.0f;
        TurnNum = 0;
        RandomNum = Random.Range(1, 8);
        BeforeNum = 5;
        ArrowLine.PointA = PersonPoint[5];
        ArrowLine.PointB = PersonPoint[RandomNum];
        IsGameStart = true;
        IsPlayerLeftMove = true;
        IsPlayerRightMove = true;

        ExclamationMark[0].enabled = false;
        ExclamationMark[1].enabled = false;
        ExclamationMark[2].enabled = false;
        ExclamationMark[3].enabled = false;
        ExclamationMark[4].enabled = false;
        ExclamationMark[5].enabled = false;
        ExclamationMark[6].enabled = false;
        ExclamationMark[7].enabled = false;

        Shake_ComputerPerson();
    }

    void GameOver(int taggerNum) {
        IsGameStart = false;
        ExclamationMark[taggerNum].enabled = true;
    }

    void GameWin() {
        RandomNum = Random.Range(0, 8);
        ArrowLine.PointA = ArrowLine.PointB;
        ArrowLine.PointB = PersonPoint[RandomNum];

        int TempRan = Random.Range(1, 2);
        if (RandomNum >= 4 && RandomNum <= 6 && TempRan == 1) {
            GameOver(RandomNum - 1);
            HorizontalShake_CompterPerson(Person[RandomNum + 1]);
        }
        else if (RandomNum >= 4 && RandomNum <= 6 && TempRan == 2) {
            HorizontalShake_CompterPerson(Person[RandomNum - 1]);
            GameOver(RandomNum + 1);
        }
        else if (RandomNum == 7 && TempRan == 1) {
            GameOver(6);
            HorizontalShake_CompterPerson(Person[2]);
        }
        else if (RandomNum == 7 && TempRan == 2) {
            HorizontalShake_CompterPerson(Person[6]);
            GameOver(2);
        }
        else if (RandomNum == 3 && TempRan == 1) {
            GameOver(1);
            HorizontalShake_CompterPerson(Person[4]);
        }
        else if (RandomNum == 3 && TempRan == 2) {
            HorizontalShake_CompterPerson(Person[1]);
            GameOver(4);
        }
        else if (RandomNum == 1 || RandomNum == 2) {
            GameOver((RandomNum == 1) ? 3 : 7);
        }
        else if (RandomNum == 0 && TempRan == 1) {
            GameOver(1);
            HorizontalShake_CompterPerson(Person[2]);
        }
        else if (RandomNum == 0 && TempRan == 2) {
            HorizontalShake_CompterPerson(Person[1]);
            GameOver(2);
        }
    }

    void NextTurn_Computer() {
        if (TimerUpper == 2.0f) {
            BeforeNum = RandomNum;
            RandomNum = Random.Range(1, 21);
            if (RandomNum <= 15)
                RandomNum = (RandomNum - 1) / 5;
            else
                RandomNum -= 14;

            RecurrsiveArrowLine.enabled = false;
            ArrowLine.PointA = ArrowLine.PointB;
            ArrowLine.PointB = PersonPoint[RandomNum];
        }

        if (ArrowLine.PointA == ArrowLine.PointB) {
            RecurrsiveArrowLine.enabled = true;
            RecurrsiveArrowLine.transform.position = ArrowLine.PointA;
        }
    }

    void ChoiceTurn_Player() {
        ArrowLine.PointA = ArrowLine.PointB;
        VerticalShakePerson(Person[BeforeNum]);
        IsPlayerChoiceTurn = true;
    }

    public void MouseClick_Character(int index) {
        if (IsPlayerChoiceTurn == true) {
            RandomNum = index;
            BeforeNum = 0;
            IsPlayerChoiceTurn = false;
            IsPlayerLeftMove = true;
            IsPlayerRightMove = true;
            ArrowLine.PointA = PersonPoint[0];
            ArrowLine.PointB = PersonPoint[index];
            Shake_ComputerPerson();
            TimerUpper = 2.0f;
            time = 0.0f;
        }
    }

    void Shake_ComputerPerson() {
        VerticalShakePerson(Person[BeforeNum]);

        if (RandomNum >= 4 && RandomNum <= 6) {
            HorizontalShake_CompterPerson(Person[RandomNum - 1]);
            HorizontalShake_CompterPerson(Person[RandomNum + 1]);
        }
        else if (RandomNum == 7) {
            HorizontalShake_CompterPerson(Person[6]);
            HorizontalShake_CompterPerson(Person[2]);
        }
        else if (RandomNum == 3) {
            HorizontalShake_CompterPerson(Person[1]);
            HorizontalShake_CompterPerson(Person[4]);
        }
        else if (RandomNum == 1 || RandomNum == 2) {
            HorizontalShake_CompterPerson(Person[(RandomNum == 1) ? 3 : 7]);
            IsPlayerLeftMove = false;
            IsPlayerRightMove = false;
        }
        else if (RandomNum == 0) {
            HorizontalShake_CompterPerson(Person[1]);
            HorizontalShake_CompterPerson(Person[2]);
        }
    }

    void LeftShake_PlayerPerson() {
        if (IsPlayerLeftMove == false) {
            Person[0].DORotate(new Vector3(0.0f, 0.0f, 20.0f), 0.3f);
            Person[0].DORotate(new Vector3(0.0f, 0.0f, 0.0f), 0.3f).SetDelay(0.3f);
            IsPlayerLeftMove = true;
        }
        else {
            GameOver(0);
        }
    }

    void RightShake_PlayerPerson() {
        if (IsPlayerRightMove == false) {
            Person[0].DORotate(new Vector3(0.0f, 0.0f, -20.0f), 0.3f);
            Person[0].DORotate(new Vector3(0.0f, 0.0f, 0.0f), 0.3f).SetDelay(0.3f);
            IsPlayerRightMove = true;
        }
        else {
            GameOver(0);
        }
    }

    void HorizontalShake_CompterPerson(RectTransform Person) {
        Person.DORotate(new Vector3(0.0f, 0.0f, 20.0f), 0.3f);
        Person.DORotate(new Vector3(0.0f, 0.0f, -20.0f), 0.6f).SetDelay(0.3f);
        Person.DORotate(new Vector3(0.0f, 0.0f, 0.0f), 0.3f).SetDelay(0.7f);
    }

    void VerticalShakePerson(RectTransform Person) {
        Person.DOJump(Person.transform.position, 25.0f, 1, 0.5f, true);
        Person.DOJump(Person.transform.position, 25.0f, 1, 0.5f, true).SetDelay(0.9f);
    }
}