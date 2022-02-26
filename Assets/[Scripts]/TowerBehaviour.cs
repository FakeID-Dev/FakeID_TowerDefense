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
    private TowerPlacement towerPlacement;

    public GameObject bulletSpawnLocation;

    bool hasTarget = false;
    //public GameObject target;

    private float lastAttack = 0f;

    public List<GameObject> targetList = new List<GameObject>();

    private void Start()
    {
        gameObject.GetComponent<SphereCollider>().radius = aimRadius;
        Debug.Log("TOWER BEHAVIOUR STARTING");
        towerPlacement = gameObject.GetComponent<TowerPlacement>();

        

        ///lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (targetList[0] != null)
        {
            if (!towerPlacement.holding)
                Fire();

            //gameObject.transform.LookAt(new Vector3(target.transform.position.x, 0, target.transform.position.z));
        }

        //DrawCircle(16, aimRadius);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //target = other.gameObject;
            targetList.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject == target)
        //{
        //    target = null;
        //}

        if (targetList.Contains(other.gameObject))
        {
            targetList.Remove(other.gameObject);
        }
    }


    private void Fire()
    {
        if (Time.time > lastAttack + rateOfFire)

        { 
            lastAttack = Time.time;
            GameObject firedProjectile = Instantiate(projectileType, bulletSpawnLocation.transform.position, gameObject.transform.rotation);

            if (firedProjectile.GetComponent<ArrowBehaviour>())
                firedProjectile.GetComponent<ArrowBehaviour>().target = targetList[0];
            else if (firedProjectile.GetComponent<CannonballBehaviour>())
            {
                firedProjectile.GetComponent<CannonballBehaviour>().target = targetList[0];

            }
            gameObject.GetComponent<AudioSource>().Play();


        }

    }

    private void FixedUpdate()
    {
        foreach(GameObject _target in targetList)
        {
            if (_target == null)
            {
                targetList.Remove(_target);
                break;
            }
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
