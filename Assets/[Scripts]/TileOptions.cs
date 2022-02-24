using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileOptions : MonoBehaviour
{
    public int posX;
    public int posY;
    public GameObject Panel;
    public GameObject hovered;
    public GameObject road1;
    public GameObject road2;
    public bool isSelected = false;
    private float angle;
    private float distance;
    public bool hover;
    public bool UIcover = false;
    public GameObject gameManager; 

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        hover = false;
    }
    // Update is called once per frame
    void Update()
    {
        UIcover = EventSystem.current.IsPointerOverGameObject();

        if (EventSystem.current.IsPointerOverGameObject())
        {
            isSelected = false;
        }

        if (isSelected)
        {

            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetDir = hit.transform.position - transform.position;
                angle = Vector3.Angle(targetDir, transform.forward);

                float distance = Vector3.Distance(hit.transform.position, transform.position);
                GameObject temp;

                if (angle == 180)
                {
                    temp = Instantiate(road1, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.2f, gameObject.transform.position.z), road1.transform.rotation);
                    gameManager.GetComponent<Initialize>().tileList.Add(temp);
                    gameManager.GetComponent<Initialize>().roadList.Add(temp);
                    AddToMapArray();
                    gameObject.SetActive(false);
                }

                if (angle == 90)
                {
                    temp = Instantiate(road2, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.2f, gameObject.transform.position.z), road2.transform.rotation);
                    gameManager.GetComponent<Initialize>().tileList.Add(temp);
                    gameManager.GetComponent<Initialize>().roadList.Add(temp);
                    AddToMapArray();
                    gameObject.SetActive(false);
                }

                if (angle >= 0 && angle <= 45 && distance == 1)
                {
                    temp = Instantiate(road1, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.2f, gameObject.transform.position.z), road1.transform.rotation);
                    gameManager.GetComponent<Initialize>().tileList.Add(temp);
                    gameManager.GetComponent<Initialize>().roadList.Add(temp);
                    AddToMapArray();
                    gameObject.SetActive(false);
                }

            }

           

        }
    }

    public void OnMouseDown()
    {
        if (gameManager.GetComponent<Inventory>().holding == false)
        {
            if (hover)
            {
                isSelected = true;
            }
        }
    }

    public void OnMouseUp()
    {
        if (gameManager.GetComponent<Inventory>().holding == false)
        {
            if (isSelected)
            {
                //gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.y);
            }
            isSelected = false;
        }
    }


    public void OnMouseEnter()
    {
        if(gameManager.GetComponent<Inventory>().holding == false && UIcover == false)
        {
            if (isSelected == false)
            {
                gameObject.transform.position += new Vector3(0, 0.2f, 0);
                hover = true;
            }
        }

    }

    public void OnMouseExit()
    {
        if (gameManager.GetComponent<Inventory>().holding == false)
        {
            if (isSelected == false)
            {
                Vector3 temp1 = transform.position;
                temp1.y = 0.0f;
                transform.position = temp1;
                hover = false;
            }
        }
    }


    void AddToMapArray()
    {
        isSelected = false;
        for (int x = 0; x < 50; x++)
        {
            for (int y = 0; y < 50; y++)
            {
                gameManager.GetComponent<Initialize>().Map[posX, posY] = 1;
            }
        }
        gameManager.GetComponent<Initialize>().UpdateRoad(posX, posY);
    }

}
