using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StorkController : CustomBehaviour
{

    private Rigidbody _rigidbody;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private bool _isMoving;

    private Vector3 _oldVelocity;
    private Vector3 _oldAngularVelocity;

    private Camera _camera;
    private LineRenderer _lineRenderer;

    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private bool _isTurning;
    [SerializeField] private float _rotateAmount;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _lineRenderer = GetComponent<LineRenderer>();
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        if (!_isMoving) return;

        _rigidbody.velocity = transform.up * _moveSpeed * Time.fixedDeltaTime;
        if (!_isTurning)
        {
            _rigidbody.angularVelocity = Vector3.zero;
        }
        else
        {
            var direction = (transform.position - _targetPosition).normalized;

            _rotateAmount = Vector3.Cross(direction, transform.up).y;

            if ((transform.position - _targetPosition).sqrMagnitude < 1f)
            {
                _isTurning = false;
            }
            _rigidbody.angularVelocity = transform.forward * -_rotateAmount * (_turnSpeed * Time.fixedDeltaTime);
        }
        
        
        
    }

    private void Update()
    {
        if (_isMoving) return;

        if (EventSystem.current.IsPointerOverGameObject()) return;
        

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15f);
            
            Vector3 mousePosition = _camera.ScreenToWorldPoint(mousePos);

            mousePosition.y = transform.position.y;
            DrawLine(mousePosition);
            _targetPosition = mousePosition;
            _isTurning = true;
        }
    }

    int vertexCount = 24;

    private void DrawLine(Vector3 target)
    {
        var pointList = new List<Vector3>();

        Vector3 point1 = transform.position;
        Vector3 point2 = transform.position + (transform.up * 3f);
        Vector3 point3 = target;

        Debug.Log(point3 + " " + point2 + " " + point1);

        pointList.Add(transform.position);
        for(float i = 0f; i < 1f; i += 1f/ vertexCount)
        {
            var tangent1= Vector3.Lerp(point1, point2, i);
            var tangent2= Vector3.Lerp(point2, point3, i);
            var curve = Vector3.Lerp(tangent1, tangent2, i);
            pointList.Add(curve);
        }

        _lineRenderer.positionCount = pointList.Count;
        _lineRenderer.SetPositions(pointList.ToArray());
    }

    public void Pause()
    {
        _oldVelocity = _rigidbody.velocity;
        _oldAngularVelocity = _rigidbody.angularVelocity;
        _rigidbody.Sleep();
        _isMoving = false;
    }

    public void Resume()
    {
        _rigidbody.WakeUp();
        _rigidbody.velocity = _oldVelocity;
        _rigidbody.angularVelocity = _oldAngularVelocity;
        _isMoving = true;
    }
}
