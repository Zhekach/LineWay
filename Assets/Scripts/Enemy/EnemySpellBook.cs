using System;
using UnityEngine;

public class EnemySpellBook : MonoBehaviour
{

    [SerializeField] private string _enemyTag = "Enemy";
    [SerializeField] private EnemyType _enemyType;

    public bool IsActivated;

    public static Action<GameObject, EnemyType> OnEnemySpellActivated;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(_enemyTag) && IsActivated)
        {
            var enemy = collision.gameObject;
            
            OnEnemySpellActivated?.Invoke(enemy, _enemyType);
        }
        
        IsActivated = false;
        gameObject.SetActive(false);
    }
}

public enum EnemyType
{
    Wizard,
    Zombie,
    Warrior
}