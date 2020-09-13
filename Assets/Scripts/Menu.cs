using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Работа с интерфейсами
using UnityEngine.SceneManagement; //Работа со сценами
using UnityEngine.Audio; //Работа с аудио


public class Menu : MonoBehaviour
{
    public GameObject MainMenu;
    public bool isOpened = true; //Открыто ли меню
    public float volume = 0; //Громкость
    public AudioMixerGroup Mixer; //Регулятор громкости

    public void ShowHideMenu()
    {
        isOpened = !isOpened;
        GameState.IsPaused = isOpened;
        MainMenu.SetActive(isOpened);
    }

    public void ChangeVolume(float val) //Изменение звука
    {
        volume = val;
        Mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, volume));
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
    void Start()
    {
        GameState.IsPaused = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowHideMenu();
        }
    }
}
