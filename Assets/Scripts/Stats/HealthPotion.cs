using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    [SerializeField] private string _playerTag = "Player";
    [SerializeField] private int _health = 1;
    public static Action<int> OnHealthCollected;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_playerTag))
        {
            OnHealthCollected?.Invoke(_health);
            Destroy(gameObject);
        }
    }
}
