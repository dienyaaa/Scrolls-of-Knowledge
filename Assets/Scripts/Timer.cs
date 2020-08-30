using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
public float timer = 600;
public Text timeText;

    private DateTime timerEnd;

    // Start is called before the first frame update
    private void Start()
    {
        timerEnd = DateTime.Now.AddSeconds(timer);
    }

    // Update is called once per frame
    private void Update()
    {
        TimeSpan delta = timerEnd - DateTime.Now;
        timeText.text = delta.Minutes.ToString("00") + ":" + delta.Seconds.ToString("00");
        if (delta.TotalSeconds <= 0)
        {
            Debug.Log("The END");
        }
    }
}
