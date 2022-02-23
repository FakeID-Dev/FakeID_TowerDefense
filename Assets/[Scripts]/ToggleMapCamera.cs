using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMapCamera : MonoBehaviour
{
    [SerializeField] private Camera GameplayCamera; 
    [SerializeField] private Camera MapCamera;
    private Camera currentCamera;


    //[SerializeField] private Canvas GameplayUI;     // to toggle on/off gameplay UI
    //[SerializeField] private Canvas MapUI;          // for turning on any Map UI

    void Start()
    {
        GameplayCamera.enabled = true;
        //GameplayUI.enabled = GameplayCamera.enabled;

        MapCamera.enabled = false;
        //MapUI.enabled = MapCamera.enabled;

        currentCamera = GameplayCamera;
    }

    void Update()
    {
        // ToggleMap can later be called by a ui button press or otherwise as needed
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleMap();
        }
    }


    public void ToggleMap()
    {
        // turn off one camera to use the other
        if(GameplayCamera.enabled)
        {
            MapCamera.enabled = true;
            GameplayCamera.enabled = false;
            currentCamera = MapCamera;
        }
        else
        {
            GameplayCamera.enabled = true;
            MapCamera.enabled = false;
            currentCamera = GameplayCamera;
        }

        // turn off one UI canvas to use the other
        //MapUI.enabled = MapCamera.enabled;
        //GameplayUI.enabled = GameplayCamera.enabled;
    }

    public void ToggleActiveCameraMove()
    {
        bool currentDrag = currentCamera.GetComponent<MoveCamera>().canDragCamera;
        currentCamera.GetComponent<MoveCamera>().canDragCamera = !currentCamera;
    }


}
