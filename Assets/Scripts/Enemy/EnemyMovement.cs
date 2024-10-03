using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _velocity = 1;
    
    private Vector2 _targetPosition;

    private void FixedUpdate()
    {
        _targetPosition = _target.gameObject.transform.position;
        //_rigidbody.position =
            //Vector2.MoveTowards(_rigidbody.position, _targetPosition, _velocity * Time.fixedDeltaTime);
            _rigidbody.AddForce(new Vector3(-1,0,0), ForceMode2D.Force);
    }
}
