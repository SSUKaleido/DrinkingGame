using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class STBerryGamemanager : MonoBehaviour
{
    public Image[] Player;
    public Image Strawberry, StartButton, AddButton, Exit;
    public Slider SliderT;
    bool GameMode = false;
    int PlayerNumber, TurnNumber, PlayerEnter, Performance;
    float MaxTime, MinTime;

    void Awake()
    {
        Player[0].enabled = false;
        Player[1].enabled = false;
        Player[2].enabled = false;
        Player[3].enabled = false;
        Player[4].enabled = false;
        Player[5].enabled = false;
        Player[6].enabled = false;
        Player[7].enabled = false;
        MaxTime = 0.5f;
        MinTime = 0.5f;
    }
    // Start is called before the first frame update
    IEnumerator Start()
    {
        Strawberry.gameObject.SetActive(false);
        PlayerNumber = Random.Range(3, 9);
        for (int i = 0; i<PlayerNumber;i++)
        {
            Player[i].enabled = true;
            yield return new WaitForSeconds(0.25f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        SliderT.value = (float)MinTime/MaxTime;
        if (GameMode == true)
        {
            if (MinTime < 0)
            {
                MinTime = 0.5f;
            }
            else
            {
                MinTime -= Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.S))
                PlayerEnter++;
            if (TurnNumber == 0)
            {
                StartCoroutine("Progress_PlayerTurn");
            }
            else
            {
                StartCoroutine("Progress_ComputerTurn");
            }   
        }
    }
    void GameStart()
    {
        GameMode = true;
        Performance = 1;
        TurnNumber = Random.Range(0, PlayerNumber);
        StartButton.gameObject.SetActive(false);
        Player[TurnNumber].transform.localScale = new Vector2(1.5f, 1.5f);
    }
    void NextTurn()
    {
        Player[TurnNumber].transform.localScale = new Vector2(1f, 1f);
        if (TurnNumber == PlayerNumber-1)
            TurnNumber = 0;
        else
            TurnNumber++;
        Player[TurnNumber].transform.localScale = new Vector2(1.5f, 1.5f);
        if (Performance == 8)
            Performance = 1;
        else
            Performance++;
        StopAllCoroutines();
    }
    IEnumerator Progress_ComputerTurn()
    {
        if (Performance <= 4)
        {
            yield return new WaitForSeconds(2f - 0.5f * Performance);
            for (int A = Performance; A > 0; A--)
            {
                Strawberry.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Strawberry.gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                Strawberry.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Strawberry.gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
            }
            yield return new WaitForSeconds(2f - (0.5f * (Performance - 4)));
            for (int B = Performance - 4; B > 0; B--)
            {
                Strawberry.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Strawberry.gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
            }
        }
        NextTurn();
    }
    IEnumerator Progress_PlayerTurn()
    {
        if (Performance <= 4)
        {
            yield return new WaitForSeconds(2f - 0.5f * Performance);
            for (int C = Performance; C > 0; C--)
            {
                PlayerPerformance();
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                PlayerPerformance();
            }
            yield return new WaitForSeconds(2f - (0.5f * (TurnNumber - 4)));
            for (int D = Performance - 4; D > 0; D--)
            {
                PlayerPerformance();
            }
        }
        NextTurn();
    }
    IEnumerator PlayerPerformance()
    {
        Strawberry.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        Strawberry.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.25f);
        if (PlayerEnter == 1)
        {
            PlayerEnter = 0;
        }
        else
        {
            GameMode = false;
        }
    }
}