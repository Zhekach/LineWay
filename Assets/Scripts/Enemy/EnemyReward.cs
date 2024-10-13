using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReward : MonoBehaviour
{
    [SerializeField] private int _reward = 1;
    [SerializeField] private EnemyType _enemyType;

    private void OnEnable()
    {
        EnemySpellBook.OnEnemySpellActivated += HandleSpell;
    }
    private void OnDisable()
    {
        EnemySpellBook.OnEnemySpellActivated -= HandleSpell;
    }

    public void HandleSpell(GameObject enemy, EnemyType enemyType)
    {
        Debug.Log("EnemyDetected");
        if (enemy == gameObject && enemyType == _enemyType)
        {
            //TODO add reward
            Destroy(gameObject);
        }
    }
}
