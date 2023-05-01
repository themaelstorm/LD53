using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAgent : CustomAgent
{
    [SerializeField] private float _speed;

    public override void Init(GameManager gameManager)
    {
        base.Init(gameManager);

        _rigidbody.velocity = transform.forward * _speed;
        _isMoving = true;
    }

    private void Update()
    {
        if (!_isMoving) return;

        if (transform.position.y < 0f)
            ResetMe();
    }

    private void ResetMe()
    {
        _gameManager.Levels.RemoveAgent(this);

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;

        ObjectPool.Instance.BulletPool.Release(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            _gameManager.Events.HitPlayer();
        }

        ResetMe();
    }

}
