using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leveling : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject levelPanel;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        checkLevel();
    }

    public void checkLevel()
    {
        if (gameManager.GetComponent<Inventory>().expSlider.value == gameManager.GetComponent<Inventory>().expSlider.maxValue)
        {
            //Debug.Log("LEVEL UP");
            levelPanel.SetActive(true);

            gameManager.GetComponent<Inventory>().expSlider.maxValue = (float)(gameManager.GetComponent<Inventory>().expSlider.maxValue * 1.2);
        }
       
    }

    public void ResourceNode()
    {
        gameManager.GetComponent<Initialize>().AddResourceNode();
        levelPanel.SetActive(false);
        gameManager.GetComponent<Inventory>().expSlider.value = 0;
        gameManager.GetComponent<Inventory>().expInt = 0;

    }

    public void MonsterNode()
    {
        gameManager.GetComponent<Initialize>().AddMonsterNode();
        levelPanel.SetActive(false);
        gameManager.GetComponent<Inventory>().expSlider.value = 0;
        gameManager.GetComponent<Inventory>().expInt = 0;

    }

}
