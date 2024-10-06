using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    
    [SerializeField] private bool _isReady;
    [SerializeField] private bool _isMoving;

    [SerializeField] private Vector2 _targetPosition;
    [SerializeField] private float _velocity;
    
    private void Start()
    {
        gameObject.SetActive(false);
        _isReady = true;
    }
    
    private void FixedUpdate()
    {
        if (_isMoving)
        {
            _rigidbody.position =
                Vector2.MoveTowards(_rigidbody.position, _targetPosition, _velocity * Time.fixedDeltaTime);

            if (_rigidbody.position == _targetPosition)
            {
                _isMoving = false;
                transform.localPosition = Vector3.zero;
                gameObject.SetActive(false);
                _isReady = true;
            }
        }
    }
    
    public void Shoot(Vector2 targetPosition)
    {
        if (_isReady)
        {
            gameObject.SetActive(true);
            _isMoving = true;
            _isReady = false;
            _targetPosition = targetPosition;
        }
    }
}
