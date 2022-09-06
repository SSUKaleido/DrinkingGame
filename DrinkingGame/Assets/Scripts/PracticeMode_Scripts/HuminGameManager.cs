using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HuminGameManager : MonoBehaviour
{

    public Image timeImage;
    public float duration, currentTime;

    // giveConsonants
    public List<string> consonantList = new List<string>() { "ぁ", "い", "ぇ", "ぉ", "け", "げ", "さ", "し", "じ", "ず", "せ", "ぜ", "そ", "ぞ" };
    public TextMeshProUGUI consonants;
    int start = 0;
    int rand1, rand2;
    int randConsUni1, randConsUni2;

    // getAnswer
    public string playerAnswer = null;
    public TMP_InputField playerAnswerInput;

    // answerCheck
    int playerAnswerUni1, playerAnswerUni2;
    //public GameObject o;
    //public GameObject x;

    void Awake()
    {

    }


    void Start()
    {
        currentTime = duration;

        //o.SetActive(false);
        //x.SetActive(false);
    }

    void Update()
    {
        if (start == 0 && Input.GetButtonDown("Submit"))
        {
            playerAnswerInput.text = "";
            giveConsonants();
            start = 1;
        }
        else if (Input.GetButtonDown("Submit") && start == 1)
        {
            getAnswer();
            answerCheck();
            start = 0;
        }
    }

    void giveConsonants()
    {
        rand1 = Random.Range(0, consonantList.Count);
        rand2 = Random.Range(0, consonantList.Count);

        randConsUni1 = rand1;
        randConsUni2 = rand2;

        consonants.text = consonantList[rand1] + consonantList[rand2];

    }

    void getAnswer()
    {
        playerAnswer = playerAnswerInput.text;
        print(playerAnswer);
        print(playerAnswer[0]);
    }


    void answerCheck()
    {
        if (0xac00 < playerAnswer[0] && playerAnswer[0] < 0xae4b) playerAnswerUni1 = 0;
        else if (0xb098 < playerAnswer[0] && playerAnswer[0] < 0xb2e3) playerAnswerUni1 = 1;
        else if (0xb2e4 < playerAnswer[0] && playerAnswer[0] < 0xb52f) playerAnswerUni1 = 2;
        else if (0xb77c < playerAnswer[0] && playerAnswer[0] < 0xb9c7) playerAnswerUni1 = 3;
        else if (0xb9c8 < playerAnswer[0] && playerAnswer[0] < 0xbc13) playerAnswerUni1 = 4;
        else if (0xbc14 < playerAnswer[0] && playerAnswer[0] < 0xbe5f) playerAnswerUni1 = 5;
        else if (0xc0ac < playerAnswer[0] && playerAnswer[0] < 0xc2f7) playerAnswerUni1 = 6;
        else if (0xc544 < playerAnswer[0] && playerAnswer[0] < 0xc78f) playerAnswerUni1 = 7;
        else if (0xc790 < playerAnswer[0] && playerAnswer[0] < 0xc9db) playerAnswerUni1 = 8;
        else if (0xcc28 < playerAnswer[0] && playerAnswer[0] < 0xce73) playerAnswerUni1 = 9;
        else if (0xce74 < playerAnswer[0] && playerAnswer[0] < 0xd0bf) playerAnswerUni1 = 10;
        else if (0xd0c0 < playerAnswer[0] && playerAnswer[0] < 0xd30b) playerAnswerUni1 = 11;
        else if (0xd30c < playerAnswer[0] && playerAnswer[0] < 0xd557) playerAnswerUni1 = 12;
        else if (0xd558 < playerAnswer[0] && playerAnswer[0] < 0xd7a3) playerAnswerUni1 = 13;

        if (0xac00 < playerAnswer[1] && playerAnswer[1] < 0xae4b) playerAnswerUni2 = 0;
        else if (0xb098 < playerAnswer[1] && playerAnswer[1] < 0xb2e3) playerAnswerUni2 = 1;
        else if (0xb2e4 < playerAnswer[1] && playerAnswer[1] < 0xb52f) playerAnswerUni2 = 2;
        else if (0xb77c < playerAnswer[1] && playerAnswer[1] < 0xb9c7) playerAnswerUni2 = 3;
        else if (0xb9c8 < playerAnswer[1] && playerAnswer[1] < 0xbc13) playerAnswerUni2 = 4;
        else if (0xbc14 < playerAnswer[1] && playerAnswer[1] < 0xbe5f) playerAnswerUni2 = 5;
        else if (0xc0ac < playerAnswer[1] && playerAnswer[1] < 0xc2f7) playerAnswerUni2 = 6;
        else if (0xc544 < playerAnswer[1] && playerAnswer[1] < 0xc78f) playerAnswerUni2 = 7;
        else if (0xc790 < playerAnswer[1] && playerAnswer[1] < 0xc9db) playerAnswerUni2 = 8;
        else if (0xcc28 < playerAnswer[1] && playerAnswer[1] < 0xce73) playerAnswerUni2 = 9;
        else if (0xce74 < playerAnswer[1] && playerAnswer[1] < 0xd0bf) playerAnswerUni2 = 10;
        else if (0xd0c0 < playerAnswer[1] && playerAnswer[1] < 0xd30b) playerAnswerUni2 = 11;
        else if (0xd30c < playerAnswer[1] && playerAnswer[1] < 0xd557) playerAnswerUni2 = 12;
        else if (0xd558 < playerAnswer[1] && playerAnswer[1] < 0xd7a3) playerAnswerUni2 = 13;

        if (randConsUni1 == playerAnswerUni1 && randConsUni2 == playerAnswerUni2) print("you done it");
        else print("you miss it");


    }
}
