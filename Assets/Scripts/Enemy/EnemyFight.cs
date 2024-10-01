using System;
using UnityEngine;

public class EnemyFight : MonoBehaviour
{
    [SerializeField] private int _healthDamage = -1;
    [SerializeField] private string _playerTag = "Player";

    public static Action<int> OnEnemyFought;
      private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_playerTag))
        {
            OnEnemyFought?.Invoke(_healthDamage);
        }
    }
}
