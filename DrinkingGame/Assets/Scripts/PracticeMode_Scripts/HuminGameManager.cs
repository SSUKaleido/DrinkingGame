using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HuminGameManager : MonoBehaviour
{

    public TextMeshProUGUI consonants;
    public Image timeImage;
    public float duration, currentTime;
    public List<string> consonantList = new List<string>() { "ぁ", "い", "ぇ", "ぉ", "け", "げ", "さ", "し", "じ", "ず", "せ", "ぜ", "そ", "ぞ" };
    public TMP_InputField playerAnswerInput;
    public string playerAnswer = null;
    

    int start = 0;
    int rand1, rand2;
    // Start is called before the first frame update
    
    void Start()
    {
        currentTime = duration;
        playerAnswer = playerAnswerInput.GetComponent<InputField>().text;
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetButtonDown("Submit") && start == 0)
        {
            start = 1;
            giveConsonants();
            getAnswer();
            //answerCheck();
        }
    }

    void giveConsonants() 
    {
        rand1 = Random.Range(0, consonantList.Count);
        rand2 = Random.Range(0, consonantList.Count);

        consonants.text = consonantList[rand1] + consonantList[rand2];
    }

    void getAnswer()
    {
        while(true)
        {
            if(playerAnswer.Length > 0 && Input.GetButtonDown("Submit"))
            {
                playerAnswer = playerAnswerInput.text;
                break;
            }
        }
    }

    /*void answerCheck()
    {

    }
    */
}
    
