//############################################################################################################
// Pause.sc
// Erik Enos 100994107
// Date: 2022-02-05
// 
//############################################################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public bool pause = false;
    public GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pause == true)
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
        pause = true;
        //TODO: Pause Game
        Time.timeScale = 0;
    }

    public void OnClickResume()
    {
        pause = false;
        //TODO: Unpause Game
        Time.timeScale = 1;
    }
}
