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

    public bool isOpen = false;
    public bool holding = false;

    public GameObject Tower_1;
    public GameObject Tower_2;
    public GameObject Tower_3;
    public GameObject Tower_4;
    public GameObject Tower_5;
    public GameObject currentTower;
    public GameObject invPanel;
    public GameObject infoPanel;
    public GameObject buildButton;

    public Text coinTxt;
    //public Text stoneTxt;
    public Text crystalTxt;

    public Slider expSlider;

    public int coinInt = 0;
    //public int stoneInt = 0;
    public int crystalInt = 0;
    public int expInt = 0;

    private int coinTemp = 0;
    //private int stoneTemp = 0;
    private int crystalTemp = 0;
    private int expTemp = 0;

    [Header("Arrow Tower")]
    public int tower1GoldCost;
    public int tower1CrystalCost;
    [Header("Ice Tower")]
    public int tower2GoldCost;
    public int tower2CrystalCost;
    [Header("Cannon Tower")]
    public int tower3GoldCost;
    public int tower3CrystalCost;
    [Header("Driller Tower")]
    public int tower4GoldCost;
    public int tower4CrystalCost;
    [Header("Collector Tower")]
    public int tower5GoldCost; 
    public int tower5CrystalCost;


    // Start is called before the first frame update
    void Start()
    {
        coinInt = 20;
        //stoneInt = 6;
        crystalInt = 10;
        expInt = 0;
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
        //stoneTxt.text = "STONE: " + stoneInt;
        crystalTxt.text = "CRYSTAL: " + crystalInt;
        expSlider.value = expInt;
    }

    public void MousPos()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (holding)
        {
            if (Physics.Raycast(ray, out hit))
            {
                currentTower.transform.position = new Vector3(hit.point.x, 0, hit.point.z);
            }

            if (Input.GetMouseButtonUp(0))
            {

                if (currentTower.GetComponentInChildren<TowerPlacement>().canBePlaced == true)
                {
                    holding = false;
                    currentTower.GetComponentInChildren<TowerPlacement>().PlacedTower();
                    currentTower = null;


                }
                else
                {
                    isOpen = false;
                    gameObject.GetComponent<Initialize>().toggleTiles();
                    gameObject.GetComponent<ToggleMapCamera>().ToggleActiveCameraMove();

                    Destroy(currentTower);
                    holding = false;
                    currentTower = null;

                    //stoneInt = stoneTemp;
                    coinInt = coinTemp;
                }
            }

        }

    }


    //Buttons
    public void InvButtonSlider()
    {
        //Debug.Log("Opening Menu Panel");
        if (isOpen == false)
        {
            isOpen = true;
            invPanel.SetActive(true); //Opens Inv
        }
        else if (isOpen)
        {
            isOpen = false;
            invPanel.SetActive(false);//closes Inv  
        }
    }

    public void InvButtonTowerPlace1()  // Arrow tower
    {
        //stoneInt >= 1 &&
        if ( coinInt >= tower1GoldCost && crystalInt >= tower1CrystalCost)
        {
            currentTower = Instantiate(Tower_1, new Vector3(0, 0, 0), Quaternion.identity);
            holding = true;
            //invPanel.transform.position = pos;
            invPanel.SetActive(false);
            //stoneTemp = stoneInt;
            coinTemp = coinInt;
            //stoneInt--;
            coinInt -= tower1GoldCost;
            crystalInt -= tower1CrystalCost;
        }

    }

    public void InvButtonTowerPlace2()  // Ice Tower
    {
        //stoneInt >= 1 &&
        if (coinInt >= tower2GoldCost && crystalInt >= tower2CrystalCost)
        {
            currentTower = Instantiate(Tower_2, new Vector3(0, 0, 0), Quaternion.identity);
            holding = true;
            //invPanel.transform.position = pos;
            invPanel.SetActive(false);
            //stoneTemp = stoneInt;
            coinTemp = coinInt;
            //stoneInt -= 1;
            coinInt -= tower2GoldCost;
            crystalInt -= tower2CrystalCost;

        }
    }

    public void InvButtonTowerPlace3()  // Cannon tower
    {
        //stoneInt >= 3 &&
        if (coinInt >= tower3GoldCost && crystalInt >= tower3CrystalCost)
        {
            currentTower = Instantiate(Tower_3, new Vector3(0, 0, 0), Quaternion.identity);
            holding = true;
            //invPanel.transform.position = pos;
            invPanel.SetActive(false);
            //stoneTemp = stoneInt;
            coinTemp = coinInt;
            //stoneInt -= 3;
            coinInt -= tower3GoldCost;
            crystalInt -= tower3CrystalCost;
        }
    }

    public void InvButtonTowerPlace4()  // Driller Tower
    {
        if (coinInt >= tower4GoldCost && crystalInt >= tower4CrystalCost)
        {
            currentTower = Instantiate(Tower_4, new Vector3(0, 0, 0), Quaternion.identity);
            holding = true;
            //invPanel.transform.position = pos;
            invPanel.SetActive(false);
            //stoneTemp = stoneInt;
            coinTemp = coinInt;
            //stoneInt -= 3;
            coinInt -= tower4GoldCost;
            crystalInt -= tower4CrystalCost;
        }
    }

    public void InvButtonTowerPlace5()  // Storage tower
    {
        if (coinInt >= tower5GoldCost && crystalInt >= tower5CrystalCost)
        {
            currentTower = Instantiate(Tower_5, new Vector3(0, 0, 0), Quaternion.identity);
            holding = true;
            //invPanel.transform.position = pos;
            invPanel.SetActive(false);
            //stoneTemp = stoneInt;
            coinTemp = coinInt;
            //stoneInt -= 3;
            coinInt -= tower5GoldCost;
            crystalInt -= tower5CrystalCost;
        }
    }

    public void ClearTowers()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("tower");

        foreach (var tower in towers)
        {
            Destroy(tower);   
        }
    }

    public void loadPlaceTower(float xPos, float zPos, int type)
    {
        //Debug.Log(type);
        if (type == 0)
        {
            currentTower = Instantiate(Tower_1, new Vector3(xPos, 0.2f, zPos), Quaternion.identity);
        }
        else if (type == 1)
        {
            currentTower = Instantiate(Tower_2, new Vector3(xPos, 0.2f, zPos), Quaternion.identity);
        }
        else if (type == 2)
        {
            currentTower = Instantiate(Tower_3, new Vector3(xPos, 0.2f, zPos), Quaternion.identity);
        }
        else if (type == 3)
        {
            currentTower = Instantiate(Tower_4, new Vector3(xPos, 0.2f, zPos), Quaternion.identity);
        }
        else if (type == 4)
        {
            currentTower = Instantiate(Tower_5, new Vector3(xPos, 0.2f, zPos), Quaternion.identity);
        }
        else
        {
            holding = false;
            return;
        }
        currentTower.GetComponentInChildren<TowerPlacement>().LoadPlacedTower();
        holding = false;
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
