using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RabbitGameManager : MonoBehaviour
{
    public ImageLineRenderer ArrowLine;
    public Image RecurrsiveArrowLine;
    public RectTransform[] Person;
    public Slider TimerSlider;

    Vector3[] PersonPoint = new Vector3[8];

    int TaggerNum = 0, RandomNum;
    float time = 0.0f , TimerUpper = 0.5f;
    bool IsGameStart = false, IsPlayerLeftMove = true, IsPlayerRightMove = true;

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

        RecurrsiveArrowLine.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameStart == true) {
            time += Time.deltaTime;
            if (time > TimerUpper)
                NextTurn_Computer();

            TimerSlider.value = (time / TimerUpper);

            if (IsPlayerLeftMove == false && Input.GetKeyDown(KeyCode.LeftArrow))
                IsPlayerLeftMove = LeftShake_PlayerPerson();
            if (IsPlayerRightMove == false && Input.GetKeyDown(KeyCode.RightArrow))
                IsPlayerRightMove = RightShake_PlayerPerson();
        }
    }

    public void GameStart() {
        time = 0.0f;
        ArrowLine.PointA = PersonPoint[0];
        ArrowLine.PointB = PersonPoint[0];
        IsGameStart = true;
    }

    void NextTurn_Computer() {
        time = 0.0f;
        if (TimerUpper == 2.0f) {
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

        if ((RandomNum >= 4 && RandomNum <= 6) && TimerUpper == 0.5f) {
            HorizontalShake_CompterPerson(Person[RandomNum - 1]);
            HorizontalShake_CompterPerson(Person[RandomNum + 1]);
        }
        else if (RandomNum == 7 && TimerUpper == 0.5f) {
            HorizontalShake_CompterPerson(Person[6]);
            HorizontalShake_CompterPerson(Person[2]);
        }
        else if (RandomNum == 3 && TimerUpper == 0.5f) {
            HorizontalShake_CompterPerson(Person[1]);
            HorizontalShake_CompterPerson(Person[4]);
        }
        else if ((RandomNum == 1 || RandomNum == 2) && TimerUpper == 0.5f) {
            HorizontalShake_CompterPerson(Person[(RandomNum == 1) ? 3 : 7]);
            IsPlayerLeftMove = false;
            IsPlayerRightMove = false;
        }
        else if (RandomNum == 0 && TimerUpper == 0.5f) {
            HorizontalShake_CompterPerson(Person[1]);
            HorizontalShake_CompterPerson(Person[2]);
        }

        if (TimerUpper == 0.5f)
            TimerUpper = 2.0f;
        else if (TimerUpper == 2.0f)
            TimerUpper = 0.5f;
    }

    bool LeftShake_PlayerPerson() {
        Person[0].DORotate(new Vector3(0.0f, 0.0f, 20.0f), 0.3f);
        Person[0].DORotate(new Vector3(0.0f, 0.0f, 0.0f), 0.3f).SetDelay(0.3f);
        return true;
    }

    bool RightShake_PlayerPerson() {
        Person[0].DORotate(new Vector3(0.0f, 0.0f, -20.0f), 0.3f);
        Person[0].DORotate(new Vector3(0.0f, 0.0f, 0.0f), 0.3f).SetDelay(0.3f);
        return true;
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