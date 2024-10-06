using System;
using UnityEngine;

public class EnemySpellBook : MonoBehaviour
{

    [SerializeField] private string _enemyTag = "Enemy";
    [SerializeField] private EnemyType _enemyType;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_enemyTag))
        {
            EnemyReward enemyReward = collision.gameObject.GetComponent<EnemyReward>();
            enemyReward.HandleSpell(_enemyType);
            Destroy(gameObject);
        }
    }
}

public enum EnemyType
{
    Wizard,
    Zombie,
    Warrior
}