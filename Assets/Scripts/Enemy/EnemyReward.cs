using System;
using System.Collections;
using System.Collections.Generic;
using Stats;
using UnityEngine;

public class EnemyReward : MonoBehaviour
{
    [SerializeField] private int _reward = 1;
    [SerializeField] private EnemyType _enemyType;

    public static Action<int> OnEnemyDefeated;

    private void OnEnable()
    {
        EnemySpellBook.OnEnemySpellActivated += HandleSpell;
        HealthCounter.OnEnemyDestroyedByPlayer += HandlePlayerAttack;
    }
    private void OnDisable()
    {
        EnemySpellBook.OnEnemySpellActivated -= HandleSpell;
        HealthCounter.OnEnemyDestroyedByPlayer -= HandlePlayerAttack;
    }

    private void HandlePlayerAttack(GameObject enemy)
    {
        if (enemy == gameObject)
        {
            DestroyEnemy();
        }
    }
    
    private void HandleSpell(GameObject enemy, EnemyType enemyType)
    {
        Debug.Log("EnemyDetected");
        if (enemy == gameObject && enemyType == _enemyType)
        {
            DestroyEnemy();
        }
    }

    private void DestroyEnemy()
    {
        OnEnemyDefeated?.Invoke(_reward);
        Destroy(gameObject);
    }
}
