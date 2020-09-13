using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timer = 1800;
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
        if (GameState.IsPaused)
            return;
        timer -= Time.deltaTime;
        timeText.text = Format((int)timer);
        if (timer <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    private string Format(int seconds)
    {
        var minutes = seconds/60;
        var newSeconds = seconds-minutes*60;
        var stringSeconds = newSeconds>9?newSeconds.ToString():$"0{newSeconds}";
        return $"{minutes}:{stringSeconds}";
    }
}
