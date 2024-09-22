using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public bool Move;
    [SerializeField] private WayDrawer _wayDrawer;
    [SerializeField] private float _moveSpeed = 3f;
    private Rigidbody2D _rb;
    private Vector3 _position;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if(Move)
        {
            if(_wayDrawer.Line.positionCount > 0)
            {
                _position = _wayDrawer.Line.GetPosition(0);
                if(Vector2.Distance(transform.position, _position) > 0.1f)
                {
                    _rb.position = Vector2.Lerp(_rb.position, _position, _moveSpeed * Time.fixedDeltaTime);
                }
                else
                {
                    var positions = _wayDrawer.Positions;
                    if (positions.Count > 0)
                    {
                        positions.RemoveAt(0);
                        _wayDrawer.SetPositions(positions.ToArray());
                    }
                    else
                    {
                        StopMove();
                    }
                }
            }
        }
    }
    public void StopMove()
    {
        _wayDrawer.ClearWayPoints();
        _wayDrawer.Line.positionCount = 0;
        Move = false;
    }
}
