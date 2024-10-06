using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _velocity = 1;


    private void FixedUpdate()
    {
            Vector3 direction = _target.gameObject.transform.position - gameObject.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            direction.Normalize();
            Vector2 movement = direction;
            _rigidbody.MovePosition(transform.position + direction * _velocity * Time.deltaTime);
    }
}
