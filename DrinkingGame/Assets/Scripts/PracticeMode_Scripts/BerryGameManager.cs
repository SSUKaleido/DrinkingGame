using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryGameManager : MonoBehaviour
{
    int PlayerNumber, PlayerEnterNum = 0;
    float time = 0.0f, FunctionStartTime = 0.0f;
    bool IsGameStart = false, IsPlayersTurn = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameStart == true)
            time += Time.deltaTime;
    }

    public void GameStart() {
        IsGameStart = true;
        PlayerNumber = Random.Range(1, 9);
    }

    IEnumerator Progress_CompterTurn(int NowOrder) {
        if (NowOrder <= 4)
            yield return new WaitForSeconds(1.0f - (0.25f * NowOrder));
        else 
            yield return new WaitForSeconds(2.0f - (0.25f * NowOrder));

        for (int CurrentOrder = NowOrder; CurrentOrder > 0; CurrentOrder--) {
            yield return new WaitForSeconds(0.25f);
            SlapAction();
        }
    }

    IEnumerator Progress_PlayerTurn(int NowOrder) {
        if (NowOrder <= 4)
            yield return new WaitForSeconds(1.0f - (0.25f * NowOrder));
        else 
            yield return new WaitForSeconds(2.0f - (0.25f * NowOrder));

        IsPlayersTurn = true;
        for (int CurrentOrder = NowOrder; CurrentOrder > 0; CurrentOrder--) {
            yield return new WaitForSeconds(0.25f);
            if (PlayerEnterNum == 1)
                ;//return true;
            else {
                IsPlayersTurn = false;
                //return false;
            }
        }
        IsPlayersTurn = false;
    }

    void Progress_PlayerTurn_enter() {
        PlayerEnterNum++;
    }

    void SlapAction() {
        
    }
 }