using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyHitPoint=5;
    void Start()
    {
        
    }
    void Update()
    {
        KillEnemy();
    }
    void OnParticleCollision(GameObject other)
    {
        enemyHitPoint--;   
    }
    void KillEnemy()
    {
        if(enemyHitPoint < 1)
        {
            gameObject.SetActive(false);
            enemyHitPoint = 5;
        }
    }
}
