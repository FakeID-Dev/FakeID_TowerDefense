using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballBehaviour : MonoBehaviour
{
    public GameObject target;
    private Vector3 targetPos; 
    [SerializeField] float flySpeed;

    public AudioClip hitSound;


    void Start()
    {
        targetPos = target.transform.position;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, flySpeed);

        if (transform.position == targetPos)
        {
            Detonate();
        }
    }


    private void Detonate()
    {
        AudioSource.PlayClipAtPoint(hitSound, transform.position, 1.0f);
        Destroy(gameObject);
    }

}
