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
    int number = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        TimerSlider.value = time;
        g369number.text = number.ToString();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            number += 1;
            clap.enabled = false;

        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            number += 1;
            clap.enabled = true;

        }

    }


    // 글자 색 모음string[] color_str = { "abdee6", "cbaacb", "ffffb5", "ffccb6", "f3b0c3", "000000"};
    // 글자 색 인덱스int index = 0;private void Button_Click(object sender, RoutedEventArgs e){    
    // 라벨 색 변경    L1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff" + color_str[index++]));    
    // 색상 변경    if (index == color_str.Length){index = 0;}}
    
}
