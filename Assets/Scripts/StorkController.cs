using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
        _rigidbody.angularVelocity = transform.forward * _turnSpeed * Time.fixedDeltaTime;
    }

    private void Update()
    {
        if (_isMoving) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitData;
            if (Physics.Raycast(ray, out hitData, 1000))
            {
                Vector3 mousePosition = hitData.point;
                Debug.Log(mousePosition);
                mousePosition.y = transform.position.y;
                DrawLine(mousePosition);
                Debug.Log(mousePosition);
            }
            
        }
    }

    int vertexCount = 24;

    private void DrawLine(Vector3 target)
    {
        var pointList = new List<Vector3>();

        Vector3 point1 = transform.position;
        Vector3 point2 = transform.position + (transform.up * _moveSpeed);
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
