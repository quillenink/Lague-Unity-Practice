using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEngine.UI;

public class EP4 : MonoBehaviour
{
    public TMP_Text dstDisplay;
    public Vector2 point1, point2;

    int frameCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        print("Start");

        float dst = GetDistanceBetweenTwoPoints(point1.x, point1.y, point2.x, point2.y);
        print(dst);
    }

    // Update is called once per frame
    void Update()
    {
        frameCount += 1;
        //print("Frame Count: " + frameCount);
    }

    float GetDistanceBetweenTwoPoints(float x1, float y1, float x2, float y2)
    {
        float dX = x2 - x1;
        float dY = y2 - y1;
        float dstSquared = dX * dX + dY * dY;
        float dst = Mathf.Sqrt(dstSquared);
        return dst;
    }

    public void ComputeDistance()
    {
        float distance = GetDistanceBetweenTwoPoints(point1.x, point1.y, point2.x, point2.y);
        dstDisplay.text = new string("" + distance);
        //return distance;
    }
}
