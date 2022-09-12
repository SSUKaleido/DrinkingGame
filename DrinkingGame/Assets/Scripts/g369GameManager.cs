using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class g369GameManager : MonoBehaviour
{
    public Image clap;
    public TextMeshProUGUI g369number;
    public Slider TimerSlider;

    float time = 0.0f, delay = 0.0f;
    int number = 1;

    // Game over
    public GameObject tilePrefab;
    public Transform backgroundNode;
    public Transform boardNode;
    public Transform tetrominoNode;
    public GameObject gameoverPanel;

    // Start is called before the first frame update
    void Start()
    {
        gameoverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        TimerSlider.value = time;
        g369number.text = number.ToString();

        if (number == 1)
        {
            clap.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (number % 10 == 3 || number % 10 == 6 || number % 10 == 9)
            {
                gameoverPanel.SetActive(true);
            }
            else 
            {
                number += 1;
                clap.enabled = false;
            }

        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (number % 10 == 3 || number % 10 == 6 || number % 10 == 9)
            {
                number += 1;
                clap.enabled = true;
            }
            else
            {
                gameoverPanel.SetActive(true);
            }
        }

    }
}


