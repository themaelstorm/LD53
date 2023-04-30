using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class StorkController : CustomAgent
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private GameObject _targetArrow;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _turnSpeed;

    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private bool _isTurning;
    [SerializeField] private float _rotateAmount;

    [SerializeField] private float _cameraToPlayerDistance;


    public override void Init(GameManager gameManager)
    {
        base.Init(gameManager);
        
        if (_lineRenderer == null)
            _lineRenderer = GetComponent<LineRenderer>();

        _cameraToPlayerDistance = _camera.transform.position.y - transform.position.y;

    }

    private void FixedUpdate()
    {
        if (!_isMoving) return;

        _rigidbody.velocity = transform.forward * _moveSpeed * Time.fixedDeltaTime;
        if (!_isTurning)
        {
            _rigidbody.angularVelocity = Vector3.zero;
        }
        else
        {
            var direction = (transform.position - _targetPosition).normalized;

            _rotateAmount = Vector3.Cross(direction, transform.forward).y;

            if ((transform.position - _targetPosition).sqrMagnitude < 1f)
            {
                _isTurning = false;
            }
            _rigidbody.angularVelocity = Vector3.up * _rotateAmount * (_turnSpeed * Time.fixedDeltaTime);
        }
                
    }

    private void Update()
    {
        if (_isMoving) return;

        if (EventSystem.current.IsPointerOverGameObject()) return;
        

        if (Input.GetMouseButtonDown(0))
        {
            _targetArrow.SetActive(true);
        }
        /*
        if (Input.GetMouseButtonUp(0))
        {
            _targetArrow.SetActive(false);
            _lineRenderer.positionCount = 0;
        }
        */
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cameraToPlayerDistance);
            
            Vector3 mousePosition = _camera.ScreenToWorldPoint(mousePos);

            mousePosition.y = transform.position.y;
            DrawLine(mousePosition);
            _targetPosition = mousePosition;
            _isTurning = true;

            SetTargetArrow();
        }
    }

    private void SetTargetArrow()
    {
        var rotateAmount = Vector3.Angle(transform.position, _targetPosition);

        _targetArrow.transform.position = _targetPosition;
        _targetArrow.transform.rotation = Quaternion.Euler(Vector3.up * (rotateAmount));
    }

    int vertexCount = 24;

    private void DrawLine(Vector3 target)
    {
        var pointList = new List<Vector3>();

        Vector3 point1 = transform.position;
        Vector3 point2 = transform.position + (transform.forward * 5f);
        Vector3 point3 = target;

        //Debug.Log(point3 + " " + point2 + " " + point1);

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

}
