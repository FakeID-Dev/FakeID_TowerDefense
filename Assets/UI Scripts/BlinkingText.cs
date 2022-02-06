using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{
    public float highRange;
    public float lowRange;

    public float transparencyVal;

    void Update()
    {
        //Ping pong transparency value
        float tempVal = highRange - lowRange;
        transparencyVal = Mathf.PingPong(Time.time, 1.0f);

        Color colour = Color.black;

        colour.a = lowRange + (transparencyVal * tempVal);
        //Set colour between low range and high range
        GetComponent<Text>().color = colour;

    }
}
