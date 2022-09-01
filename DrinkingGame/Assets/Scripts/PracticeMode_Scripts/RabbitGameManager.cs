using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RabbitGameManager : MonoBehaviour
{
    ImageLineRenderer ArrowLine;

    Vector3 PlayerPoint = new Vector3(960, 340, 0);
    Vector3 Person1Point = new Vector3(1101.4214f, 399.4214f, 0);
    Vector3 Person2Point = new Vector3(1160, 540, 0);
    Vector3 Person3Point = new Vector3(1101.4214f, 681.4214f, 0);
    Vector3 Person4Point = new Vector3(960, 740, 0);
    Vector3 Person5Point = new Vector3(818.4214f, 681.4214f, 0);
    Vector3 Person6Point = new Vector3(760, 540, 0);
    Vector3 Person7Point = new Vector3(818.4214f, 399.4214f, 0);

    void Awake() {
        ArrowLine = GameObject.Find("ArrowLine").GetComponent<ImageLineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ArrowLine.PointA = Person3Point;
        ArrowLine.PointB = PlayerPoint;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
