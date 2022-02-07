using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    [SerializeField] private float dragSpeed = 0.5f;
    private Vector3 dragOrigin;

    public bool canDragCamera = true;

    void Update()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        if (canDragCamera)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = Input.mousePosition;
                return;
            }

            if (!Input.GetMouseButton(0)) return;

            Vector3 pos = gameObject.GetComponent<Camera>().ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(-pos.x * dragSpeed, 0, -pos.y * dragSpeed);

            transform.Translate(move, Space.World);
        }
    }

}


//Vector3 pos = gameObject.GetComponent<Camera>().ScreenToViewportPoint(Input.mousePosition - dragOrigin);