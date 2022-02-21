//############################################################################################################
// Inventory.sc
// Erik Enos 100994107
// Date: 2022-02-05
// 
//############################################################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    
    private Vector3 pos; 

    private bool isOpen = false;
    private bool holding = false;

    public GameObject Tower_1;
    public GameObject Tower_2;
    public GameObject Tower_3;
    public GameObject currentTower;
    public GameObject invPanel;
    public GameObject infoPanel;
    public GameObject buildButton;

    public Text coinTxt;
    public int coinInt = 0;


    // Start is called before the first frame update
    void Start()
    {
        pos = invPanel.transform.position;  
    }

    // Update is called once per frame
    void Update()
    {
        MousPos();
        updateUI();
    }

    public void updateUI()
    {
        coinTxt.text = "GOLD: " + coinInt;
    }

    public void MousPos()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (holding)
        {
            if (Physics.Raycast(ray, out hit))
            {
                currentTower.transform.position = hit.point;
            }

            if(Input.GetMouseButtonDown(0)) {
                
                if(currentTower.GetComponentInChildren<TowerPlacement>().canBePlaced == true)
                {
                    holding = false;
                    currentTower.GetComponentInChildren<TowerPlacement>().PlacedTower();
                    currentTower = null;
                    

                }
            }

        }
       
    }

    
    //Buttons
    public void InvButtonSlider()
    {
        if (isOpen == false)
        {
            invPanel.transform.position -= new Vector3(250.0f, 0.0f, 0.0f); //Opens Inv
            isOpen = true;
            buildButton.SetActive(false);
        }
        else if (isOpen)
        {
            invPanel.transform.position = pos;//closes Inv
            isOpen = false;
            buildButton.SetActive(true);
        }
    }

    public void InvButtonTowerPlace1()
    {
        currentTower = Instantiate(Tower_1, new Vector3(0, 0, 0), Quaternion.identity);
        holding = true;
        invPanel.transform.position = pos;
        buildButton.SetActive(true);
    }

    public void InvButtonTowerPlace2()
    {
        currentTower = Instantiate(Tower_2, new Vector3(0, 0, 0), Quaternion.identity);
        holding = true;
        invPanel.transform.position = pos;
        buildButton.SetActive(true);
    }


    public void InvButtonTowerPlace3()
    {
        currentTower = Instantiate(Tower_3, new Vector3(0, 0, 0), Quaternion.identity);
        holding = true;
        invPanel.transform.position = pos;
        buildButton.SetActive(true);
    }

    public void onHoverTowerEnter()
    {
        infoPanel.SetActive(true);
    }

    public void onHoverTowerExit()
    {
        infoPanel.SetActive(false);
    }


}
