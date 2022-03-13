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

    public bool canDragCamera = true;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        if (canDragCamera)
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

            transform.position = new Vector3(basePos.x + ((clickOrigin.x - dragOrigin.x) * .01f), transform.position.y, basePos.z + ((clickOrigin.y - dragOrigin.y) * .01f));

            if(Input.touchCount >= 1)
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

            transform.position = new Vector3(basePos.x + ((touchOrigin.x - dragOrigin.x) * .01f), transform.position.y, basePos.z + ((touchOrigin.y - dragOrigin.y) * .01f));

        }


    }

}

