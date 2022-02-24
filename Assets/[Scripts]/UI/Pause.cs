//############################################################################################################
// Pause.cs
// Erik Enos #100994107
// Morgan Ethier #101230557
// Date: 2022-02-05
// 
// Updated 2022-02-22: Pause Functionality Added, Return To Main Menu
//############################################################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPaused == true)
        {
            pausePanel.SetActive(true);
        }
        else
        {
            pausePanel.SetActive(false);
        }
    }

    public void OnClickPause()
    {
        isPaused = true;
        Time.timeScale = 0;
    }

    public void OnClickResume()
    {
        isPaused = false;
        Time.timeScale = 1;
    }

    public void OnClickSave()
    {
        //TODO: Save Implementation
        print("Saving!");
    }

    public void OnClickExit()
    {
        print("Returning to Main Menu");
        SceneManager.LoadScene("MenuUI");
    }
}
