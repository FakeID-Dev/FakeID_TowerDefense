using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMapCamera : MonoBehaviour
{
    [SerializeField] private Camera GameplayCamera; 
    [SerializeField] private Camera MapCamera;
    [SerializeField] private Canvas GameplayUI;     // to toggle on/off gameplay UI
    [SerializeField] private Canvas MapUI;          // for turning on any Map UI

    void Start()
    {
        GameplayCamera.enabled = true;
        GameplayUI.enabled = GameplayCamera.enabled;

        MapCamera.enabled = false;
        MapUI.enabled = MapCamera.enabled;
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
        GameplayCamera.enabled = !GameplayCamera.enabled;
        MapCamera.enabled = !MapCamera.enabled;

        // turn off one UI canvas to use the other
        MapUI.enabled = MapCamera.enabled;
        GameplayUI.enabled = GameplayCamera.enabled;
    }

}
