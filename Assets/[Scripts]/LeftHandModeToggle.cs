using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandModeToggle : MonoBehaviour
{
    [SerializeField] GameObject rightPanel;
    [SerializeField] GameObject leftPanel;

    GameObject gameManager;
    Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        inventory = gameManager.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inventory.LeftHandMode)
        {
            rightPanel.SetActive(false);
            leftPanel.SetActive(true);
        }
        else
        {
            leftPanel.SetActive(false);
            rightPanel.SetActive(true);
        }
    }
}
