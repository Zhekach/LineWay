using System;
using UnityEngine;

public class PlayerShieldBook : MonoBehaviour
{

    [SerializeField] private string _playerTag = "Player";

    public bool IsActivated;

    public static Action OnPlayerShieldActivated;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(_playerTag) && IsActivated)
        {
            var enemy = collision.gameObject;
            
            OnPlayerShieldActivated?.Invoke();
        }
        
        IsActivated = false;
        gameObject.SetActive(false);
    }
}