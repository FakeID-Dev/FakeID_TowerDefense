//############################################################################################################
// MenuUIController.cs
// Morgan Ethier #101230557
// 
// Updated 2022-02-23: Added functionality to swap between main menu UI screens
//############################################################################################################
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    //Canvases
    public GameObject TitleScreenCanvas;
    public GameObject MainMenuCanvas;
    public GameObject Instructions1Canvas;
    public GameObject Instructions2Canvas;
    public GameObject OptionsCanvas;

    public GameObject soundManager;
    public GameObject musicManager;

    private bool musicPlaying;
    private bool sfxPlaying;

    public GameObject musicOn;
    public GameObject musicOff;
    public GameObject sfxOn;
    public GameObject sfxOff;

    void Start()
    {
        TitleScreenCanvas.SetActive(true);
        MainMenuCanvas.SetActive(false);
        Instructions1Canvas.SetActive(false);
        Instructions2Canvas.SetActive(false);
        OptionsCanvas.SetActive(false);

        if (PlayerPrefs.GetInt("MusicPlaying") == 0)
        {
            musicManager.GetComponent<AudioSource>().Play();
            musicOn.SetActive(true);
            musicOff.SetActive(false);
        }
        else
        {
            musicOn.SetActive(false);
            musicOff.SetActive(true);
        }

        if (PlayerPrefs.GetInt("SFXPlaying") == 0)
        {
            sfxOn.SetActive(true);
            sfxOff.SetActive(false);
        }
        else
        {
            sfxOn.SetActive(false);
            sfxOff.SetActive(true);
        }
    }

    void Update()
    {
        musicPlaying = (PlayerPrefs.GetInt("MusicPlaying") == 0);
        sfxPlaying = (PlayerPrefs.GetInt("SFXPlaying") == 0);
    }

    public void OnMainMenuClicked()
    {
        TitleScreenCanvas.SetActive(false);
        MainMenuCanvas.SetActive(true);
        Instructions1Canvas.SetActive(false);
        Instructions2Canvas.SetActive(false);
        OptionsCanvas.SetActive(false);

        if (sfxPlaying)
            soundManager.GetComponent<AudioSource>().Play();
    }

    public void OnStartClicked()
    {
        //Start Game

        if (sfxPlaying)
            soundManager.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("GameScene");

    }

    public void OnInstructions1Clicked()
    {
        TitleScreenCanvas.SetActive(false);
        MainMenuCanvas.SetActive(false);
        Instructions1Canvas.SetActive(true);
        Instructions2Canvas.SetActive(false);
        OptionsCanvas.SetActive(false);

        if (sfxPlaying)
            soundManager.GetComponent<AudioSource>().Play();

    }

    public void OnInstructions2Clicked()
    {
        TitleScreenCanvas.SetActive(false);
        MainMenuCanvas.SetActive(false);
        Instructions1Canvas.SetActive(false);
        Instructions2Canvas.SetActive(true);
        OptionsCanvas.SetActive(false);

        if (sfxPlaying)
            soundManager.GetComponent<AudioSource>().Play();

    }

    public void OnOptionsClicked()
    {
        TitleScreenCanvas.SetActive(false);
        MainMenuCanvas.SetActive(false);
        Instructions1Canvas.SetActive(false);
        Instructions2Canvas.SetActive(false);
        OptionsCanvas.SetActive(true);

        if(sfxPlaying)
            soundManager.GetComponent<AudioSource>().Play();
    }

    public void OnToggleMusicClicked()
    {
        if (PlayerPrefs.GetInt("MusicPlaying") == 0)
        {
            PlayerPrefs.SetInt("MusicPlaying", 1);
            musicManager.GetComponent<AudioSource>().Stop();
            musicOn.SetActive(false);
            musicOff.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("MusicPlaying", 0);
            musicManager.GetComponent<AudioSource>().Play();
            musicOn.SetActive(true);
            musicOff.SetActive(false);
        }
    }

    public void OnToggleSFXClicked()
    {
        if (PlayerPrefs.GetInt("SFXPlaying") == 0)
        {
            PlayerPrefs.SetInt("SFXPlaying", 1);
            sfxOn.SetActive(false);
            sfxOff.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("SFXPlaying", 0);
            soundManager.GetComponent<AudioSource>().Play();
            sfxOn.SetActive(true);
            sfxOff.SetActive(false);
        }
    }

}
