using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class WayDrawer : MonoBehaviour
{
    [SerializeField] private LineRenderer _pathRenderer;
    [SerializeField] private float _timeForNextRay = 0.05f;
    [SerializeField] private float _pointThresholdMin = 0.1f;
    [SerializeField] private float _pointThresholdMax = 0.5f;
    [SerializeField] private LayerMask _playerMask, _notDrawMask;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private float _wayMaxLength;
    [SerializeField] private bool _isDrawn;
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
        _isDrawn = false;
        UpdateWayCounter();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_playerMovement.IsMoving && !_isDrawn)
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector3.forward, 100f, _playerMask);
            if (hit)
            {
                _clickOnPlayer = true;
                _isDrawn = true;
                _pathRenderer.enabled = true;
                _pathRenderer.positionCount = 1;
                _pathRenderer.SetPosition(0, _playerMovement.transform.position);
            }
        }

        //TODO refactor extract methods
        if (Input.GetMouseButton(0) && _clickOnPlayer)
        {
            if (_timer >= _timeForNextRay && _wayIndex < _wayMaxLength)
            {
                var mousePosition = Camera.main.ScreenToWorldPoint(
                    new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector3.forward, 100f, _notDrawMask);
                if (!hit)
                {
                    var lastPoint = _pathRenderer.GetPosition(_pathRenderer.positionCount - 1);
                    Vector2 rayDirection = mousePosition - lastPoint;
                    float rayLength = Vector2.Distance(mousePosition, lastPoint);
                    if (Physics2D.Raycast(lastPoint, rayDirection.normalized,
                            rayDirection.magnitude, _notDrawMask) ||
                        rayLength < _pointThresholdMin) return;

                    //TODO refactor to one treshold
                    if (rayLength > _pointThresholdMax)
                    {
                        while (rayLength > 0)
                        {
                            if (rayLength > _pointThresholdMax)
                            {
                                SetPosition(lastPoint + (Vector3)rayDirection.normalized * _pointThresholdMax);
                                lastPoint += (Vector3)rayDirection.normalized * _pointThresholdMax;
                                rayLength -= _pointThresholdMax;
                            }
                            else
                            {
                                SetPosition(lastPoint + (Vector3)rayDirection.normalized * rayLength);
                                rayLength = 0;
                            }
                        }
                    }

                    SetPosition(mousePosition);
                    //

                    UpdateWayCounter();
                }

                _timer = 0;
            }
            else
            {
                _timer += Time.deltaTime;
            }
        }

        if (Input.GetMouseButtonUp(0) && !_playerMovement.IsMoving && _clickOnPlayer)
        {
            _clickOnPlayer = false;
            _wayIndex = 1;
            _playerMovement.StartMove();
        }
    }

    private void SetPosition(Vector3 mousePosition)
    {
        if (_wayIndex >= _wayMaxLength)
        {
            return;
        }

        _pathRenderer.positionCount = _wayIndex + 1;
        mousePosition.z = 0;
        _positions.Add(mousePosition);
        _pathRenderer.SetPosition(_wayIndex, mousePosition);
        _wayIndex++;
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