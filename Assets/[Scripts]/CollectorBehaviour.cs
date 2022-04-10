using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectorBehaviour : MonoBehaviour
{
    public int maxGold;
    public int currentGold;
    public float radius;
    public float absorbStep;
    private Inventory inventory;
    public TextMeshPro coinText; 

    void Start()
    {
        inventory = GameObject.Find("GameManager").GetComponent<Inventory>();
        coinText.text = "0";
    }

    void Update()
    {
        if (currentGold < maxGold)
        {
            Collider[] nearbyColliders = Physics.OverlapSphere(transform.position, radius);
            foreach (var collider in nearbyColliders)
            {
                if (collider.gameObject.CompareTag("coin"))
                {
                    collider.gameObject.transform.position = Vector3.MoveTowards(collider.gameObject.transform.position, gameObject.transform.position, absorbStep);

                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            currentGold += other.gameObject.GetComponent<CoinBehaviour>().coinValue;
            Destroy(other.gameObject);
            //Debug.Log("COLLECTING A COIN!");
            coinText.text = currentGold.ToString();
        }
    }

    private void OnMouseDown()
    {
        //Debug.Log("CLICKED ON COLLECTOR");
        inventory.coinInt += currentGold;
        currentGold = 0;
        coinText.text = currentGold.ToString();

    }
}
