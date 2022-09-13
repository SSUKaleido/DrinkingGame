using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class STBerryGamemanager : MonoBehaviour
{
    public Image[] Player;
    public Image Strawberry, StartButton, AddButton, ExitButton;
    public Slider SliderT;
    bool GameMode = false;
    bool isdelay;
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
        StartButton.gameObject.SetActive(true);
        PlayerNumber = Random.Range(3, 9);
        for (int i = 0; i<PlayerNumber;i++)
        {
            Player[i].enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
    }
     //Update is called once per frame
    void Update()
    {
        SliderT.value = (float)MinTime/MaxTime;
        if (GameMode == true)
        {
            if (isdelay==false)
            {
                isdelay = true;
                StartCoroutine("GameProgress");
                StartCoroutine("ProgressDelay");
            }
            if (MinTime < 0)
            {
                MinTime = 0.5f;
            }
            else
            {
                MinTime -= Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.Q))
                Addberry();
        }
    }
    public void Addberry()
    {
        PlayerEnter++;
    }
    public void GameStart()
    {
        GameMode = true;
        Performance = 1;
        TurnNumber = Random.Range(0, PlayerNumber);
        StartButton.gameObject.SetActive(false);
        Player[TurnNumber].transform.localScale = new Vector2(1.5f, 1.5f);
        isdelay = false;
    }
    IEnumerator GameProgress()
    {
        if (TurnNumber == 0)
        {
            if (Performance <= 4)
            {
                yield return new WaitForSeconds(2f - 0.5f * Performance);
                for (int i = Performance; i > 0; i--)
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
                        Debug.Log("실패");
                    }
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
                    if (PlayerEnter == 1)
                    {
                        PlayerEnter = 0;
                    }
                    else
                    {
                        Debug.Log("실패");
                    }
                }
                yield return new WaitForSeconds(2f - (0.5f * (Performance - 4)));
                for (int i = Performance - 4; i > 0; i--)
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
                        Debug.Log("실패");
                    }
                }
            }
        }
        else
        {
            if (Performance <= 4)
            {
                yield return new WaitForSeconds(2f - 0.5f * Performance);
                for (int i = Performance; i > 0; i--)
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
                for (int i = Performance - 4; i > 0; i--)
                {
                    Strawberry.gameObject.SetActive(true);
                    yield return new WaitForSeconds(0.25f);
                    Strawberry.gameObject.SetActive(false);
                    yield return new WaitForSeconds(0.25f);
                }
            }
        }
    }
    IEnumerator ProgressDelay()
    {
        if (Performance <=4)
        {
            yield return new WaitForSeconds(2f);
        }
        else
        {
            yield return new WaitForSeconds(4f);
        }
        Player[TurnNumber].transform.localScale = new Vector2(1f, 1f);
        if (TurnNumber == PlayerNumber - 1)
            TurnNumber = 0;
        else
            TurnNumber++;
        Player[TurnNumber].transform.localScale = new Vector2(1.5f, 1.5f);
        if (Performance == 8)
            Performance = 1;
        else
            Performance++;
        isdelay = false;
    }
    IEnumerator ComputerTurn()
    {
        Strawberry.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        Strawberry.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.25f);
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
            Debug.Log("실패");
        }
    }
    public void GameOver()
    {
        Debug.Log("???");
        Application.Quit();
    }
}