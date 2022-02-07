using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{

 
    
    [Header("Tower Properties")]
    [SerializeField] float aimRadius;
    [SerializeField] float damage;
    [SerializeField] float rateOfFire;
    [SerializeField] int storage;
    
    public GameObject projectileType;
    private LineRenderer lineRenderer;

    bool hasTarget = false;
    public GameObject target;

    private float lastAttack = 0f;


    private void Start()
    {
        gameObject.GetComponent<SphereCollider>().radius = aimRadius;
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (target != null)
        {
            Fire();

            //gameObject.transform.LookAt(new Vector3(target.transform.position.x, 0, target.transform.position.z));
        }

        //DrawCircle(16, aimRadius);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            target = null;
        }
    }


    private void Fire()
    {
        if (Time.time > lastAttack + rateOfFire)
        {
            lastAttack = Time.time;
            GameObject firedProjectile = Instantiate(projectileType, gameObject.transform.position, gameObject.transform.rotation);

            if (firedProjectile.GetComponent<ArrowBehaviour>())
                firedProjectile.GetComponent<ArrowBehaviour>().target = target;
            else if (firedProjectile.GetComponent<CannonballBehaviour>())
            {
                firedProjectile.GetComponent<CannonballBehaviour>().target = target;

            }
            gameObject.GetComponent<AudioSource>().Play();

        }

    }


    //void DrawCircle(int steps, float radius)
    //{
    //    lineRenderer.positionCount = steps;


    //    for(int currentStep = 0; currentStep < steps; currentStep++)
    //    {
    //        float circumferenceProgress = (float)currentStep / steps;

    //        float currentRadian = circumferenceProgress * (2 * Mathf.PI);

    //        float xScaled = Mathf.Cos(currentRadian);
    //        float yScaled = Mathf.Sin(currentRadian);

    //        float x = xScaled * radius;
    //        float y = yScaled * radius;

    //        Vector3 currentPosition = new Vector3(x, y, 0);

    //        lineRenderer.SetPosition(currentStep, currentPosition);
    //    }
    //}



}
