using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReward : MonoBehaviour
{
    [SerializeField] private int _reward = 1;
    [SerializeField] private EnemyType _enemyType;

    public void HandleSpell(EnemyType enemyType)
    {
        Debug.Log("EnemyDetected");
        if (enemyType == _enemyType)
        {
            //TODO add reward
            Destroy(gameObject);
        }
    }
}
