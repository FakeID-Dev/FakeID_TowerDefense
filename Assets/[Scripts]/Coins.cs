//############################################################################################################
// Coins.sc
// Erik Enos 100994107
// Date: 2022-02-05
// 
//############################################################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Coins : MonoBehaviour
{
    private int coins = 0;
    public int speedRot = 100;
    public GameObject coinPre;
    public GameObject Inv;

    // Start is called before the first frame update
    void Start()
    {
        coins = 1;
        Inv = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(coins >= 1)
        {
            coinPre.SetActive(true);
        }
        else
        {
            coinPre.SetActive(false);
        }
       
        SpinningCoin();

        OnPointerEnter();
    }


    void SpinningCoin()
    {
        coinPre.transform.Rotate(0, speedRot * Time.deltaTime, 0);
    }

    public void OnPointerEnter()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "coin")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Inv.GetComponent<Inventory>().coinInt += coins;
                    coins = 0;
                    
                }
            }
        }
    }
}
