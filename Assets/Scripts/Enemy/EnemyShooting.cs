using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
   [SerializeField] private CircleCollider2D _collider;
   [SerializeField] private string _playerTag = "Player";
   
   [SerializeField] private EnemyBullet _bullet;

   public bool test;
   
   private void OnTriggerStay2D(Collider2D collision)
   {
      if (collision.CompareTag(_playerTag))
      {
         test = true;
         Vector2 playerPosition = collision.gameObject.transform.position;
         _bullet.Shoot(playerPosition);
      }
   }
}
