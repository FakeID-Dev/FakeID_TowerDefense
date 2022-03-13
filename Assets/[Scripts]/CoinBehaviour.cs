using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    public float spinSpeed;
    public int coinValue; 
    private Inventory inventory; 



    void Start()
    {
        inventory = GameObject.Find("GameManager").GetComponent<Inventory>();
    }

    void Update()
    {
        Spin();
    }

    void Spin()
    {
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
    }

    private void OnMouseDown()
    {
        Collect();
    }

    void Collect()
    {
        inventory.coinInt+= coinValue;
        Destroy(gameObject);
    }
}
