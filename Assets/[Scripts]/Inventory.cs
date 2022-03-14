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

    private Vector3 posR;
    private Vector3 posL;

    public bool isOpen = false;
    public bool holding = false;

    public GameObject Tower_1;
    public GameObject Tower_2;
    public GameObject Tower_3;
    public GameObject currentTower;
    public GameObject invPanelRight;
    public GameObject invPanelLeft;
    public GameObject infoPanel;
    public GameObject buildButton;

    public Text coinTxt;
    public Text stoneTxt;
    public Text crystalTxt;

    public Slider expSlider;

    public int coinInt = 0;
    public int stoneInt = 0;
    public int crystalInt = 0;
    public int expInt = 0;

    private int coinTemp = 0;
    private int stoneTemp = 0;
    private int crystalTemp = 0;
    private int expTemp = 0;

    [Header("Left/Right bool and offset")]
    [SerializeField] float LeftHandOffset = -200f;
    [SerializeField] float RightHandOffset = 200f;
    public bool LeftHandMode;


    // Start is called before the first frame update
    void Start()
    {
        coinInt = 2;
        stoneInt = 6;
        crystalInt = 0;
        expInt = 0;
        posR = invPanelRight.transform.position;
        posL = invPanelLeft.transform.position;
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
        stoneTxt.text = "STONE: " + stoneInt;
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
                currentTower.transform.position = hit.point;
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

                    stoneInt = stoneTemp;
                    coinInt = coinTemp;
                }
            }

        }

    }


    //Buttons
    public void InvButtonSlider()
    {
        if (isOpen == false)
        {
            isOpen = true;
            invPanelRight.transform.position -= new Vector3(RightHandOffset, 0.0f, 0.0f); //Opens Right Inv to Right Offset
            invPanelLeft.transform.position -= new Vector3(LeftHandOffset, 0.0f, 0.0f); //Opens Left Inv to Left Offset
        }
        else if (isOpen)
        {
            isOpen = false;
            invPanelRight.transform.position = posR;//closes Inv  
            invPanelLeft.transform.position = posL;//closes Inv  
        }
    }

    public void InvButtonTowerPlace1()
    {
        if (stoneInt >= 1 && coinInt >= 1)
        {
            currentTower = Instantiate(Tower_1, new Vector3(0, 0, 0), Quaternion.identity);
            holding = true;
            invPanelRight.transform.position = posR;
            invPanelLeft.transform.position = posL;
            stoneTemp = stoneInt;
            coinTemp = coinInt;
            stoneInt--;
            coinInt--;
        }

    }

    public void InvButtonTowerPlace2()
    {
        if (stoneInt >= 1 && coinInt >= 1)
        {
            currentTower = Instantiate(Tower_2, new Vector3(0, 0, 0), Quaternion.identity);
            holding = true;
            invPanelRight.transform.position = posR;
            invPanelLeft.transform.position = posL;
            stoneTemp = stoneInt;
            coinTemp = coinInt;
            stoneInt -= 1;
            coinInt -= 1;
        }
    }

    public void InvButtonTowerPlace3()
    {
        if (stoneInt >= 3 && coinInt >= 2)
        {
            currentTower = Instantiate(Tower_3, new Vector3(0, 0, 0), Quaternion.identity);
            holding = true;
            invPanelRight.transform.position = posR;
            invPanelLeft.transform.position = posL;
            stoneTemp = stoneInt;
            coinTemp = coinInt;
            stoneInt -= 3;
            coinInt -= 2;
        }
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
