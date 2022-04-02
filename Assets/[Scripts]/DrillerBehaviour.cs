using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class DrillerBehaviour : MonoBehaviour
{
    public int maxResource;
    public int currentResource;
    public float radius;
    public float drillStep;
    public int resourcesPerDrill;
    private float lastDrill = 0;
    private Inventory inventory;
    public TextMeshPro resourceText;

    public bool isActive; 

    void Start()
    {
        inventory = GameObject.Find("GameManager").GetComponent<Inventory>();
        resourceText.text = "0";

    }

    void Update()
    {
        if (!isActive)
        {
            Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, radius);
            foreach(var collider in nearbyColliders)
            {
                if (collider.gameObject.CompareTag("crystal"))
                {
                    isActive = true;
                }
            }
        }

        if (isActive)
        {
            if (currentResource < maxResource)
            {
                lastDrill += Time.deltaTime;
                if (lastDrill > drillStep)
                {
                    currentResource += resourcesPerDrill;

                    if (currentResource > maxResource)
                    {
                        currentResource = maxResource;
                    }
                    resourceText.text = currentResource.ToString();

                    lastDrill = 0;
                }
            }
        }
    }


    private void OnMouseDown()
    {
        inventory.crystalInt += currentResource;
        currentResource = 0;
        resourceText.text = currentResource.ToString();
    }
}
