using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
   [SerializeField] private CircleCollider2D _collider;
   [SerializeField] private EnemyBullet _bullet;
   [SerializeField] private string _playerTag = "Player";

   public bool test;

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.CompareTag(_playerTag))
      {
         test = true;
      }
   }
}
