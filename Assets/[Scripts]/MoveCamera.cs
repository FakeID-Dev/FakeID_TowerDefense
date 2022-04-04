using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    Camera camera;
    private Vector3 dragOrigin;
    private Vector3 clickOrigin = Vector3.zero;
    private Vector3 touchOrigin = Vector3.zero;
    private Vector3 basePos = Vector3.zero;

    private float cameraHeight;
    [SerializeField] float heightVar = 5f;
    [SerializeField] float minHeight = 5f;
    [SerializeField] float maxHeight = 15f;

    public bool canDragCamera = true;
    public bool touchMode = false;

    void Start()
    {
        camera = GetComponent<Camera>();
        cameraHeight = transform.position.y;
    }

    void Update()
    {

        if (canDragCamera)
        {

            if (Input.GetKeyDown(KeyCode.O))
            {
                ZoomIn();
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                ZoomOut();
            }


            if (!touchMode)
            {
                if (Input.GetMouseButton(0))
                {
                    if (clickOrigin == Vector3.zero)
                    {
                        clickOrigin = Input.mousePosition;
                        basePos = transform.position;
                    }
                }
                dragOrigin = Input.mousePosition;

                if (!Input.GetMouseButton(0))
                {
                    clickOrigin = Vector3.zero;
                    return;
                }

                transform.position = new Vector3(basePos.x + ((clickOrigin.x - dragOrigin.x) * .01f), cameraHeight, basePos.z + ((clickOrigin.y - dragOrigin.y) * .01f));

            }
            else
            {

                if (Input.touchCount >= 1)
                {
                    if (touchOrigin == Vector3.zero)
                    {
                        touchOrigin = Input.GetTouch(0).position;
                        basePos = transform.position;
                    }
                    dragOrigin = Input.GetTouch(0).position;
                }

                if (Input.touchCount < 1)
                {
                    touchOrigin = Vector3.zero;
                    return;
                }

                transform.position = new Vector3(basePos.x + ((touchOrigin.x - dragOrigin.x) * .01f), cameraHeight, basePos.z + ((touchOrigin.y - dragOrigin.y) * .01f));

            }
        }


    }

    public void ZoomIn()
    {
        cameraHeight -= heightVar;
        if (cameraHeight < minHeight)
        {
            cameraHeight = minHeight;
        }
        ChangeZoom();
    }
    
    public void ZoomOut()
    {
        cameraHeight += heightVar;
        if (cameraHeight > maxHeight)
        {
            cameraHeight = maxHeight;
        }
        ChangeZoom();
    }

    private void ChangeZoom()
    {
        transform.position = new Vector3(transform.position.x, cameraHeight, transform.position.z);
    }

}
