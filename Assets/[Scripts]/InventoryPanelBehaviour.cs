using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanelBehaviour : MonoBehaviour
{
    public bool LeftHandModeOn = false;

    [SerializeField] float panelOffset = 270f;
    [SerializeField] RectTransform invPanel;
    [SerializeField] RectTransform closeButton;

    Inventory inventory;

    void Start()
    {
        inventory = GameObject.Find("GameManager").GetComponent<Inventory>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LeftHandModeOn = !LeftHandModeOn;
            if (!LeftHandModeOn)
            {
                invPanel.anchorMin = new Vector2(1, 0.5f);
                invPanel.anchorMax = new Vector2(1, 0.5f);
                invPanel.anchoredPosition = new Vector3(-panelOffset, invPanel.anchoredPosition.y, 0f);
                closeButton.anchoredPosition = new Vector3(-265, closeButton.anchoredPosition.y, 0f);
            }
            else
            {
                invPanel.anchorMin = new Vector2(0, 0.5f);
                invPanel.anchorMax = new Vector2(0, 0.5f);
                invPanel.anchoredPosition = new Vector3(panelOffset, invPanel.anchoredPosition.y, 0f);
                closeButton.anchoredPosition = new Vector3(265, closeButton.anchoredPosition.y, 0f);
            }
        }

        

    }

}
