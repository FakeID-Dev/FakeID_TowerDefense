using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    public AudioClip pickupSound;
    public float spinSpeed;
    public int coinValue; 
    private Inventory inventory;

    public float duration;
    private float remainingDuration; 


    void Start()
    {
        inventory = GameObject.Find("GameManager").GetComponent<Inventory>();
        remainingDuration = duration;
    }

    void Update()
    {
        Spin();
        remainingDuration -= Time.deltaTime;

        if (remainingDuration <= 0)
        {
            Destroy(gameObject);
        }
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
        AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        inventory.coinInt+= coinValue;
        Destroy(gameObject);
    }
}
