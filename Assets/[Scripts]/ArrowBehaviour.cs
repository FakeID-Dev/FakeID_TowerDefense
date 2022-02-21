using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    public GameObject target; 

    [SerializeField] float flySpeed;
    [SerializeField] float damage;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (!target)
        {
            Destroy(gameObject);
        }
        else
        {
            // Fly towards target
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, flySpeed);
            transform.LookAt(target.transform);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == target)
        {
            Hit(other.gameObject);
        }
    }

    private void Hit(GameObject hitObject)
    {
        GetComponent<AudioSource>().Play();
        hitObject.GetComponent<EnemyController>().TakeDamage(damage);
        Destroy(gameObject);
    }

}
