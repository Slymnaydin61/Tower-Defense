using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{

    [SerializeField] Transform balistaPosition;
    [SerializeField] ParticleSystem balistaBolt;
    [SerializeField] float balistaRange=15f;
    Transform target;

    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }

    void Update()
    {
        FindClosestTarget();
        TargetEnemy();  
    }
    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance=Mathf.Infinity;
        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if(targetDistance<maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }

        }
        target = closestTarget;
    }
    void TargetEnemy()
    {
        float targetDistance=Vector3.Distance(transform.position,target.position);
        if(targetDistance<=balistaRange)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
        balistaPosition.LookAt(target.position);
    }
    void Attack(bool isActive)
    {
        var emmisionModule = balistaBolt.emission;
        emmisionModule.enabled = isActive;
    }
}
