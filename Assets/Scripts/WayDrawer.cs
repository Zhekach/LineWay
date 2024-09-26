using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class WayDrawer : MonoBehaviour
{
    [SerializeField] private LineRenderer _pathRenderer;
    [SerializeField] private float _timeForNextRay = 0.05f, _pointThreshold = 0.1f;
    [SerializeField] private LayerMask _playerMask, _notDrawMask;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private float _wayMaxLength;
    [SerializeField] private int _wayIndex;
    [SerializeField] private TMP_Text _wayCounterText;
    private float _timer;
    private bool _clickOnPlayer;
    private List<Vector3> _positions;
    
    public List<Vector3> Positions => _positions;
    public LineRenderer Line => _pathRenderer;
    
    private void Start()
    {
        _positions = new List<Vector3>();
        _pathRenderer.enabled = false;
        _wayIndex = 0;
        UpdateWayCounter();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_playerMovement.Move)
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(
                    new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector3.forward, 100f, _playerMask);
            if (hit)
            {
                _clickOnPlayer = true;
                _pathRenderer.enabled = true;
                _pathRenderer.positionCount = 1;
                _pathRenderer.SetPosition(0, _playerMovement.transform.position);
            }
        }
        if (Input.GetMouseButton(0) && _clickOnPlayer)
        {
            if (_timer >= _timeForNextRay && _wayIndex <= _wayMaxLength - 1)
            {
                var mousePosition = Camera.main.ScreenToWorldPoint(
                    new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector3.forward, 100f, _notDrawMask);
                if (!hit)
                {
                    var lastPoint = _pathRenderer.GetPosition(_pathRenderer.positionCount - 1);
                    Vector2 rayDirection = mousePosition - lastPoint;
                    if (Physics2D.Raycast(lastPoint, rayDirection.normalized, 
                        rayDirection.magnitude, _notDrawMask) || 
                        Vector2.Distance(mousePosition, lastPoint) < _pointThreshold) return;
                    _pathRenderer.positionCount = _wayIndex + 1;
                    mousePosition.z = 0;
                    _positions.Add(mousePosition);
                    _pathRenderer.SetPosition(_wayIndex, mousePosition);
                    _wayIndex++;
                    UpdateWayCounter();
                }
                _timer = 0;
            }
            else
            {
                _timer += Time.deltaTime;
            }
        }
        if (Input.GetMouseButtonUp(0) && !_playerMovement.Move && _clickOnPlayer)
        {
            _clickOnPlayer = false;
            _wayIndex = 1;
            _playerMovement.Move = true;
        }
    }
    public void SetPositions(Vector3[] positions)
    {
        _pathRenderer.SetPositions(positions);
        _positions = positions.ToList();
    }
    public void SetWayLength(int length)
    {
        _wayMaxLength = length;
    }
    public void ClearWayPoints()
    {
        _positions.Clear();
    }

    private void UpdateWayCounter()
    {
        _wayCounterText.text = $"{_wayIndex}/{_wayMaxLength}";
    }
}
