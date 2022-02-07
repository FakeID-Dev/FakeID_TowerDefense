using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    //Canvases
    private GameObject TitleScreenCanvas;
    private GameObject MainMenuCanvas;
    private GameObject Instructions1Canvas;
    private GameObject Instructions2Canvas;
    private GameObject OptionsCanvas;

    public GameObject soundManager; 

    void Start()
    {
        GameObject[] sceneObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        foreach (GameObject go in sceneObjects)
        {
            if (go.name == "TitleScreenCanvas")
            {
                TitleScreenCanvas = go;
            }
            else if (go.name == "MainMenuCanvas")
            {
                MainMenuCanvas = go;
            }
            else if (go.name == "Instructions-1Canvas")
            {
                Instructions1Canvas = go;
            }
            else if (go.name == "Instructions-2Canvas")
            {
                Instructions2Canvas = go;
            }
            else if (go.name == "OptionsCanvas")
            {
                OptionsCanvas = go;
            }
        }

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
