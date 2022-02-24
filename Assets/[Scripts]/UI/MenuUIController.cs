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

    void Start()
    {
        TitleScreenCanvas.SetActive(true);
        MainMenuCanvas.SetActive(false);
        Instructions1Canvas.SetActive(false);
        Instructions2Canvas.SetActive(false);
        OptionsCanvas.SetActive(false);

    }

    public void OnMainMenuClicked()
    {
        TitleScreenCanvas.SetActive(false);
        MainMenuCanvas.SetActive(true);
        Instructions1Canvas.SetActive(false);
        Instructions2Canvas.SetActive(false);
        OptionsCanvas.SetActive(false);

        soundManager.GetComponent<AudioSource>().Play();
    }

    public void OnStartClicked()
    {
        //Start Game

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

        soundManager.GetComponent<AudioSource>().Play();

    }

    public void OnInstructions2Clicked()
    {
        TitleScreenCanvas.SetActive(false);
        MainMenuCanvas.SetActive(false);
        Instructions1Canvas.SetActive(false);
        Instructions2Canvas.SetActive(true);
        OptionsCanvas.SetActive(false);

        soundManager.GetComponent<AudioSource>().Play();

    }

    public void OnOptionsClicked()
    {
        TitleScreenCanvas.SetActive(false);
        MainMenuCanvas.SetActive(false);
        Instructions1Canvas.SetActive(false);
        Instructions2Canvas.SetActive(false);
        OptionsCanvas.SetActive(true);

        soundManager.GetComponent<AudioSource>().Play();

    }

}
