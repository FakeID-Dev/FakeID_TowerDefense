using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraType
{
    GAME,
    MAP
}


public class MoveCamera : MonoBehaviour
{
    public CameraType type;

    Camera camera;
    private Vector3 dragOrigin;
    private Vector3 clickOrigin = Vector3.zero;
    private Vector3 touchOrigin = Vector3.zero;
    private Vector3 basePos = Vector3.zero;

    private float cameraHeight;
    [SerializeField] float heightVar = 5f;
    [SerializeField] float minHeight = 5f;
    [SerializeField] float maxHeight = 15f;


    [SerializeField] float minVertical;
    [SerializeField] float maxVertical;
    [SerializeField] float minHorizontal;
    [SerializeField] float maxHorizontal;

    public bool canDragCamera = true;
    public bool touchMode = false;

    float initialDistance;

    void Start()
    {
        camera = GetComponent<Camera>();
        cameraHeight = transform.position.y;
    }

    void Update()
    {
        // Debug.Log(Input.touchCount);

        if (canDragCamera)
        {


            if (!touchMode)
            {
                if (Input.GetKeyDown(KeyCode.O))
                {
                    ZoomIn();
                }
                if (Input.GetKeyDown(KeyCode.I))
                {
                    ZoomOut();
                }

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

                if(Input.touchCount == 2)
                {
                    // Debug.Log("Two+ Touches");

                    var firstTouch = Input.GetTouch(0);
                    var secondTouch = Input.GetTouch(1);

                    if( firstTouch.phase == TouchPhase.Ended || firstTouch.phase == TouchPhase.Canceled || secondTouch.phase == TouchPhase.Ended || secondTouch.phase == TouchPhase.Canceled )
                    {
                        // let go
                    }
                    else if (firstTouch.phase == TouchPhase.Began || secondTouch.phase == TouchPhase.Began )
                    {
                        initialDistance = Vector2.Distance(firstTouch.position, secondTouch.position);
                    }
                    else
                    {
                        var currentDistance = Vector2.Distance(firstTouch.position, secondTouch.position);

                        if(Mathf.Approximately(initialDistance, 0))
                        {
                            // too small change
                            // Debug.Log("Too Small");
                        }
                        else // big enough to zoom
                        {
                            //Debug.Log("Camera Height: " + cameraHeight);
                            if (currentDistance > initialDistance)
                            {
                                cameraHeight--;
                            }
                            if (currentDistance < initialDistance)
                            {
                                cameraHeight++;
                            }

                            if (cameraHeight < minHeight)
                                cameraHeight = minHeight;
                            if (cameraHeight > maxHeight)
                                cameraHeight = maxHeight;

                            transform.position = new Vector3(transform.position.x, cameraHeight, transform.position.z);
                            //ChangeZoom();

                        }


                    }

                }




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
        

        if(transform.position.x > maxHorizontal)
            transform.position = new Vector3(maxHorizontal, transform.position.y, transform.position.z);
        if(transform.position.x < minHorizontal)
            transform.position = new Vector3(minHorizontal, transform.position.y, transform.position.z);
        if(transform.position.z > maxVertical)
            transform.position = new Vector3(transform.position.x, transform.position.y, maxVertical);
        if(transform.position.z < minVertical)
            transform.position = new Vector3(transform.position.x, transform.position.y, minVertical);

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

