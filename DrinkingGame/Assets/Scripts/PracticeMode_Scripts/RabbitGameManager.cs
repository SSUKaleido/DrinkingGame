using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RabbitGameManager : MonoBehaviour
{
    public ImageLineRenderer ArrowLine;
    public RectTransform[] Person;

    Vector3[] PersonPoint = new Vector3[8];

    bool IsGameStart = false;

    // Start is called before the first frame update
    void Start()
    {
        PersonPoint[0] = new Vector3(960, 340, 0);
        PersonPoint[1] = new Vector3(1101.4214f, 399.4214f, 0);
        PersonPoint[2] = new Vector3(1160, 540, 0);
        PersonPoint[3] = new Vector3(1101.4214f, 681.4214f, 0);
        PersonPoint[4] = new Vector3(960, 740, 0);
        PersonPoint[5] = new Vector3(818.4214f, 681.4214f, 0);
        PersonPoint[6] = new Vector3(760, 540, 0);
        PersonPoint[7] = new Vector3(818.4214f, 399.4214f, 0);

        ArrowLine.PointA = PersonPoint[3];
        ArrowLine.PointB = PersonPoint[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)) {
            HorizontalShakePerson(Person[1]);
       }
        if (Input.GetKeyDown(KeyCode.W)) {
            VerticalShakePerson(Person[1]);
        }
    }

    public void GameStart() {
        IsGameStart = true;
    }

    void HorizontalShakePerson(RectTransform Person) {
        Person.DORotate(new Vector3(0.0f, 0.0f, 20.0f), 0.3f);
        Person.DORotate(new Vector3(0.0f, 0.0f, -20.0f), 0.6f).SetDelay(0.3f);
        Person.DORotate(new Vector3(0.0f, 0.0f, 0.0f), 0.3f).SetDelay(0.7f);
    }

    void VerticalShakePerson(RectTransform Person) {
        Person.DOJump(Person.transform.position, 25.0f, 1, 0.5f, true);
        Person.DOJump(Person.transform.position, 25.0f, 1, 0.5f, true).SetDelay(0.9f);
    }
}