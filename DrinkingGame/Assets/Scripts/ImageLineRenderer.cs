using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLineRenderer : MonoBehaviour
{
    private RectTransform ImageRectTransform;
    public float LineWidth = 5.0f;
    public Vector3 PointA;
    public Vector3 PointB;
    // Start is called before the first frame update
    void Start()
    {
        ImageRectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 DiffernceVector = PointB - PointA;

        ImageRectTransform.sizeDelta = new Vector2(DiffernceVector.magnitude, LineWidth);
        ImageRectTransform.pivot = new Vector2(0, 0.5f);
        ImageRectTransform.position = PointA;
        float angle = Mathf.Atan2(DiffernceVector.y, DiffernceVector.x) * Mathf.Rad2Deg;
        ImageRectTransform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
