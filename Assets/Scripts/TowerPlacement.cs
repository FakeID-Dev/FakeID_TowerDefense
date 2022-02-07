//############################################################################################################
// TowerPlacement.sc
// Erik Enos 100994107
// Date: 2022-02-05
// 
//############################################################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public List<Material> met;
    public List<Color> originalMet;

    public bool canBePlaced = false;
    public bool holding = true;

    public bool tileBool = false;
    public bool roadBool = false;

    //public MeshCollider mesh;



    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < 3; x++)
        {
            originalMet[x] = GetComponent<Renderer>().materials[x].color;
            met[x] = GetComponent<Renderer>().materials[x];
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if(tileBool && roadBool)
        {
            canBePlaced = false;
        } else if (tileBool)
        {
            canBePlaced = true;
        }

        if(tileBool == false)
        {
            canBePlaced = false;
        }

        if (holding)
        {
            if (canBePlaced)
            {
                met[0].color = Color.green;
                met[1].color = Color.green;
                met[2].color = Color.green;
            }
            else
            {
                met[0].color = Color.red;
                met[1].color = Color.red;
                met[2].color = Color.red;
            }
        }
        else
        {
            for (int x = 0; x < 3; x++)
            {
               met[x].color = originalMet[x];
               Debug.Log(originalMet[x]);
            }
        }
        
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Road")
        {
            Debug.Log("can't be Placed");
            roadBool = true;
        }

        if (other.gameObject.tag == "tile" )
        {
            Debug.Log("can be Placed");
            tileBool = true;
        }


    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Road")
        {
            Debug.Log("can't be Placed");
            roadBool = false;
            tileBool = true;
        }

        if (other.gameObject.tag == "tile")
        {
            Debug.Log("can be Placed");
            tileBool = false;
        }
    }

    public void PlacedTower()
    {
       holding = false;
    }
}