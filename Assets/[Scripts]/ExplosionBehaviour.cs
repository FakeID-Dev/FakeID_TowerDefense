using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    public float damage;
    public float duration; 

    private float spawnTime = 0;

  

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime > duration)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyController hitEnemy = other.gameObject.GetComponent<EnemyController>();
        if (hitEnemy != null)
        {
            hitEnemy.TakeDamage(damage);
        }
    }
}
