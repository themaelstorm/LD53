using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomAgent : CustomBehaviour
{
    [SerializeField] protected Rigidbody _rigidbody;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected Camera _camera;

    [SerializeField] protected bool _isMoving;

    protected Vector3 _oldVelocity;
    protected Vector3 _oldAngularVelocity;

    public override void Init(GameManager gameManager)
    {
        base.Init(gameManager);

        UpdateComponents();

        _gameManager.Events.OnGamePaused += Pause;
        _gameManager.Events.OnGameResumed += Resume;
    }

    public virtual void DeInit()
    {
        _gameManager.Events.OnGamePaused -= Pause;
        _gameManager.Events.OnGameResumed -= Resume;
    }

    private void OnDestroy()
    {
        DeInit();
    }

    public virtual void UpdateComponents()
    {
        if (_rigidbody == null)
            _rigidbody = GetComponent<Rigidbody>();
        if (_animator == null)
            _animator = GetComponent<Animator>();

        _camera = Camera.main;

    }

    public virtual void Pause()
    {
        if (!_isMoving) return;
        if (_rigidbody != null)
        {
            _oldVelocity = _rigidbody.velocity;
            _oldAngularVelocity = _rigidbody.angularVelocity;
            _rigidbody.Sleep();
        }
        if (_animator != null)
        {
            _animator.speed = 0f;
        }

        _isMoving = false;
    }

    public virtual void Resume()
    {
        if (_isMoving) return;

        if (_rigidbody!= null)
        {
            _rigidbody.WakeUp();
            _rigidbody.velocity = _oldVelocity;
            _rigidbody.angularVelocity = _oldAngularVelocity;
        }

        if(_animator != null)
        {
            _animator.speed = 1f;
        }
        
        _isMoving = true;
    }
}
