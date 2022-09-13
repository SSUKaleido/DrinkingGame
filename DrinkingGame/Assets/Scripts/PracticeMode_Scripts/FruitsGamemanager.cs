using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitsGamemanager : MonoBehaviour
{
    public Image[] Player;
    public Image[] Fruits;
    public Image StartButton, AddButton, ExitButton;
    public Slider SliderT;
    bool GameMode = false;
    bool isdelay;
    int PlayerNumber, TurnNumber, BerryEnter, CarrotEnter, WaterEnter, OrientalEnter, MelonEnter, Performance;
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
        Fruits[0].enabled = false;
        Fruits[1].enabled = false;
        Fruits[2].enabled = false;
        Fruits[3].enabled = false;
        Fruits[4].enabled = false;
        MaxTime = 0.5f;
        MinTime = 0.5f;
    }
    // Start is called before the first frame update
    IEnumerator Start()
    {
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
            if (Input.GetKeyDown(KeyCode.W))
                AddCarrot();
            if (Input.GetKeyDown(KeyCode.E))
                AddWater();
            if (Input.GetKeyDown(KeyCode.R))
                AddOriental();
            if (Input.GetKeyDown(KeyCode.T))
                AddMelon();
        }
    }
    public void Addberry()
    {
        BerryEnter++;
    }
    public void AddCarrot()
    {
        CarrotEnter++;
    }
    public void AddWater()
    {
        WaterEnter++;
    }
    public void AddOriental()
    {
        OrientalEnter++;
    }
    public void AddMelon()
    {
        MelonEnter++;
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
            if (Performance == 1)
            {
                yield return new WaitForSeconds(1.5f);
                Fruits[0].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (BerryEnter == 1)
                {
                    BerryEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
            }
            if (Performance == 2)
            {
                yield return new WaitForSeconds(1f);
                Fruits[0].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (BerryEnter == 1)
                {
                    BerryEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[1].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (CarrotEnter == 1)
                {
                    CarrotEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
            }
            if (Performance == 3)
            {
                yield return new WaitForSeconds(0.5f);
                Fruits[0].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (BerryEnter == 1)
                {
                    BerryEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[1].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (CarrotEnter == 1)
                {
                    CarrotEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[2].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[2].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (WaterEnter == 1)
                {
                    WaterEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
            }
            if (Performance == 4)
            {
                Fruits[0].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (BerryEnter == 1)
                {
                    BerryEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[1].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (CarrotEnter == 1)
                {
                    CarrotEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[2].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[2].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (WaterEnter == 1)
                {
                    WaterEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[3].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[3].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (OrientalEnter == 1)
                {
                    OrientalEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
            }
            if (Performance == 5)
            {
                Fruits[0].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (BerryEnter == 1)
                {
                    BerryEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[1].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (CarrotEnter == 1)
                {
                    CarrotEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[2].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[2].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (WaterEnter == 1)
                {
                    WaterEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[3].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[3].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (OrientalEnter == 1)
                {
                    OrientalEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                yield return new WaitForSeconds(1.5f);
                Fruits[4].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[4].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (MelonEnter == 1)
                {
                    MelonEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
            }
            if (Performance == 6)
            {
                Fruits[0].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (BerryEnter == 1)
                {
                    BerryEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[1].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (CarrotEnter == 1)
                {
                    CarrotEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[2].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[2].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (WaterEnter == 1)
                {
                    WaterEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[3].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[3].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (OrientalEnter == 1)
                {
                    OrientalEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                yield return new WaitForSeconds(1f);
                Fruits[4].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[4].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (MelonEnter == 1)
                {
                    MelonEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[0].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (BerryEnter == 1)
                {
                    BerryEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
            }
            if (Performance == 7)
            {
                Fruits[0].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (BerryEnter == 1)
                {
                    BerryEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[1].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (CarrotEnter == 1)
                {
                    CarrotEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[2].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[2].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (WaterEnter == 1)
                {
                    WaterEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[3].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[3].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (OrientalEnter == 1)
                {
                    OrientalEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                yield return new WaitForSeconds(0.5f);
                Fruits[4].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[4].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (MelonEnter == 1)
                {
                    MelonEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[0].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (BerryEnter == 1)
                {
                    BerryEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[1].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (CarrotEnter == 1)
                {
                    CarrotEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
            }
            if (Performance == 8)
            {
                Fruits[0].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (BerryEnter == 1)
                {
                    BerryEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[1].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (CarrotEnter == 1)
                {
                    CarrotEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[2].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[2].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (WaterEnter == 1)
                {
                    WaterEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[3].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[3].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (OrientalEnter == 1)
                {
                    OrientalEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[4].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[4].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (MelonEnter == 1)
                {
                    MelonEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[0].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (BerryEnter == 1)
                {
                    BerryEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[1].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (CarrotEnter == 1)
                {
                    CarrotEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
                Fruits[2].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[2].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                if (WaterEnter == 1)
                {
                    WaterEnter = 0;
                }
                else
                {
                    Debug.Log("실패");
                }
            }
        }
        else
        {
            if (Performance == 1)
            {
                yield return new WaitForSeconds(1.5f);
                Fruits[0].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
            }
            if (Performance == 2)
            {
                yield return new WaitForSeconds(1f);
                Fruits[0].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
            }
            if (Performance == 3)
            {
                yield return new WaitForSeconds(0.5f);
                Fruits[0].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[2].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[2].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
            }
            if (Performance == 4)
            {
                Fruits[0].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[2].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[2].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[3].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[3].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
            }
            if (Performance == 5)
            {
                Fruits[0].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[2].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[2].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[3].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[3].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                yield return new WaitForSeconds(1.5f);
                Fruits[4].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[4].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
            }
            if (Performance == 6)
            {
                Fruits[0].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[2].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[2].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[3].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[3].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                yield return new WaitForSeconds(1f);
                Fruits[4].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[4].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
            }
            if (Performance == 7)
            {
                Fruits[0].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[2].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[2].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[3].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[3].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                yield return new WaitForSeconds(0.5f);
                Fruits[4].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[4].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
            }
            if (Performance == 8)
            {
                Fruits[0].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[2].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[2].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[3].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[3].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[4].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[4].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[0].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[1].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
                Fruits[2].gameObject.SetActive(true);
                yield return new WaitForSeconds(0.25f);
                Fruits[2].gameObject.SetActive(false);
                yield return new WaitForSeconds(0.25f);
            }
        }
    }
    IEnumerator ProgressDelay()
    {
        if (Performance <=4)
        {
            yield return new WaitForSeconds(2.01f);
        }
        else
        {
            yield return new WaitForSeconds(4.02f);
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
    public void GameOver()
    {
        Debug.Log("???");
        Application.Quit();
    }
}