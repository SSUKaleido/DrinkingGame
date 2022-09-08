using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class STBerryGamemanager : MonoBehaviour
{
    public Image[] ThisPlayerTurn;
    public Image StrawEmpty, Strawberry, StartButton, AddButton;
    bool GameMode = false;
    int TurnNumber;
    float time = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        ThisPlayerTurn[0].enabled = false;
        ThisPlayerTurn[1].enabled = false;
        ThisPlayerTurn[2].enabled = false;
        ThisPlayerTurn[3].enabled = false;
        ThisPlayerTurn[4].enabled = false;
        ThisPlayerTurn[5].enabled = false;
        ThisPlayerTurn[6].enabled = false;
        ThisPlayerTurn[7].enabled = false;
        Strawberry.enabled = false;
        StrawEmpty.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameMode == true)
            time += Time.deltaTime;
    }
    public void GameStart()
    {
        GameMode = true;
        TurnNumber = Random.Range(0, 8);
    }
    public void Shouting()
    {

    }
}