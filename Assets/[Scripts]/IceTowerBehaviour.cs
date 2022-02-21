using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTowerBehaviour : MonoBehaviour
{
    public float slowPercent;
    public float radius;
    public GameObject coldSphere; 

    void Start()
    {
        coldSphere.transform.localScale = new Vector3(radius, 0.5f, radius);
    }

}
