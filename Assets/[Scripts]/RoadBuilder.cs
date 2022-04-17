using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RoadBuilder : MonoBehaviour
{
    public List<GameObject> newRoadList;
    private GameObject startObj;
    public bool UIcover = false;
    public bool RoadSelect = false;
    private GameObject gameManager;
    public GameObject leftRoad;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = gameObject;
        GetTileList();
    }

    // Update is called once per frame
    void Update()
    {

        if (UIcover && RoadSelect)
        {
            OnTouch();
        }

    }

    private void OnTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (touch.phase == TouchPhase.Began)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.tag == "Road" || hit.transform.gameObject.tag == "tile")
                    {
                        startObj = hit.transform.gameObject;
                        newRoadList.Add(hit.transform.gameObject);
                        gameManager.GetComponent<Initialize>().tileList.Add(hit.transform.gameObject);

                    }
                }
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject.tag == "Road" || hit.transform.gameObject.tag == "tile")
                    {
                        hit.transform.gameObject.GetComponent<Renderer>().materials[1].SetColor("_Color", Color.green);

                        if (newRoadList[newRoadList.Count - 1] != hit.transform.gameObject)
                        {
                            newRoadList.Add(hit.transform.gameObject);
                            gameManager.GetComponent<Initialize>().tileList.Add(hit.transform.gameObject);
                        }
                    }
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                int x, y, size = newRoadList.Count;
                GameObject temp;
                bool up = false, down = false, left = false, right = false;

                //GetTileList();

                for (int c = 0; c < newRoadList.Count; c++)
                {
                    x = newRoadList[c].GetComponentInParent<TileOptions>().posX;
                    y = newRoadList[c].GetComponentInParent<TileOptions>().posY;

                    for (int u = 0; u < newRoadList.Count; u++)
                    {

                        if (x == newRoadList[u].GetComponentInParent<TileOptions>().posX && y + 1 == newRoadList[u].GetComponentInParent<TileOptions>().posY) 
                        {
                            newRoadList[c].GetComponentInParent<TileOptions>().up = true;
                            //Debug.Log("up");
                        }

                        if (x + 1 == newRoadList[u].GetComponentInParent<TileOptions>().posX && y == newRoadList[u].GetComponentInParent<TileOptions>().posY)
                        {
                            newRoadList[c].GetComponentInParent<TileOptions>().right = true;
                            //Debug.Log("right");
                        }

                        if (x == newRoadList[u].GetComponentInParent<TileOptions>().posX && y - 1 == newRoadList[u].GetComponentInParent<TileOptions>().posY)
                        {
                            newRoadList[c].GetComponentInParent<TileOptions>().down = true;
                            //Debug.Log("down");
                        }

                        if (x - 1 == newRoadList[u].GetComponentInParent<TileOptions>().posX && y == newRoadList[u].GetComponentInParent<TileOptions>().posY)
                        {
                            newRoadList[c].GetComponentInParent<TileOptions>().left = true;
                            //Debug.Log("LEFT");
                        }

                        
                    }
                   
                }
                
                for(int v = 0; v < newRoadList.Count;  v++)
                {
                    newRoadList[v].GetComponentInParent<TileOptions>().RoadType();
                }
                


                if (size > 1)
                {
                    for (int g = 0; g < size; g++)
                    {
                        temp = newRoadList[0];
                        newRoadList.RemoveAt(0);
                        gameManager.GetComponent<Initialize>().RemoveTile(temp);
                        Destroy(temp);
                    }
                    CanBuildRoad();
                }
                else
                {
                    //newRoadList.RemoveAt(0);
                }
 
            }
        }
    }

    public void UITOGGLE()
    {
        if (UIcover)
        {
            UIcover = false;
            RoadSelect = false;
        }
        else
        {
            UIcover = true;
        }

    }

    public void CanBuildRoad()
    {
        if (RoadSelect == false)
        {
            RoadSelect = true;
        }
        else
        {
            RoadSelect = false;
        }
    }

    public void OnBuildButtonClicked()
    {
        RoadSelect = !RoadSelect;
    }

    public void OnCancelRoadSelect()
    {
        RoadSelect = false;
    }

    public void GetTileList()
    {
        for(int c = 0; c < gameManager.GetComponent<Initialize>().tileList.Count; c++)
        {
            if(gameManager.GetComponent<Initialize>().tileList[c].gameObject.tag == "Road")
            {
                newRoadList.Add(gameManager.GetComponent<Initialize>().tileList[c]);
            } 
        }
    }
}
