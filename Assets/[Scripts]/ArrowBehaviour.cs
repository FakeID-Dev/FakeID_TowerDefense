using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    public GameObject target; 

    [SerializeField] float flySpeed;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        // Fly towards target

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, flySpeed);
        transform.LookAt(target.transform);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            Hit();
        }
    }

    private void Hit()
    {
        GetComponent<AudioSource>().Play();
        Destroy(gameObject);
    }

}
