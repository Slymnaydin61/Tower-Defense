using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Bank bank;
    [SerializeField] int goldReward = 25;
    [SerializeField] int maxHitpoints=5;
    [SerializeField] int difficultiyRamp=1;

    int enemyHitPoint;
    void OnEnable()
    {
        enemyHitPoint = maxHitpoints;
    }
    void Start()
    {
        bank =FindObjectOfType<Bank>();
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
            maxHitpoints += difficultiyRamp;
            bank.Deposit(goldReward);
        }
    }
}
