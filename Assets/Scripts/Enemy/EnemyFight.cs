using System;
using UnityEngine;

public class EnemyFight : MonoBehaviour
{
    [SerializeField] private Collider2D _enemyCollider;
    [SerializeField] private int _healthDamage = -1;
    [SerializeField] private string _playerTag = "Player";

    public static Action<int> OnEnemyFought;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_playerTag)&&
            _enemyCollider.IsTouching(collision))
        {
            OnEnemyFought?.Invoke(_healthDamage);
        }
    }
}
