using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurgeController : MonoBehaviour
{
    public Slider surgeSlider;

    private int surgeTimerInt;

    public float surgeDuration;
    private float tempDuration;

    public float surgeWait;
    private float tempWait;

    private bool surgeActive;

    // Start is called before the first frame update
    void Start()
    {
        surgeActive = false;

        tempWait = 0;
        tempDuration = surgeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (surgeActive)
        {
            CountDownSurge();
        }
        else
        {
            CountUpToSurge();
        }
    }

    private void CountUpToSurge()
    {

        surgeSlider.maxValue = surgeWait;

        if (tempWait < surgeWait)
        {
            tempWait += Time.deltaTime;

            Debug.Log("Surge Wait : " + tempWait.ToString());

            surgeSlider.value = tempWait;
        }
        else
        {
            surgeActive = true;
            tempWait = 0;
        }
    }

    private void CountDownSurge()
    {
        surgeSlider.maxValue = surgeDuration;


        if (tempDuration > 0)
        {
            tempDuration -= Time.deltaTime;

            Debug.Log("Surge Duration : " + tempDuration.ToString());

            surgeSlider.value = tempDuration;
        }
        else
        {
            surgeActive = false;
            tempDuration = surgeDuration;
        }
    }

}
