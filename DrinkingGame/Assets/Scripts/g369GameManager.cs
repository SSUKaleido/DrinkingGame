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

    float time = 0.0f;
    int number = 5;

    // Start is called before the first frame update
    void Start()
    {
        clap.enabled = false; // ÀÌ¹ÌÁö ²¨Áü
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        TimerSlider.value = time;
        g369number.text = number.ToString();
    }
}
