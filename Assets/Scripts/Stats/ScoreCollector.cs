using System;
using UnityEngine;

public class ScoreCollector : MonoBehaviour
{
    [SerializeField] private string _playerTag = "Player";

    public static Action OnScoreCollected;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_playerTag))
        {
            OnScoreCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}