using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class TurretAgent : CustomAgent
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _fireTimer;

    [SerializeField] private Transform Muzzle;

    [SerializeField] private GameObject _bulletPrefab;
    private void Update()
    {
        if (!_isMoving) return;
        if (_target == null) return;

        TurnTowardsTarget();

        _fireTimer += Time.deltaTime;
        if (_fireTimer>_fireRate)
        {
            _fireTimer = 0f;

            Shoot();
        }
    }

    private void TurnTowardsTarget()
    {
        Quaternion neededRotation = Quaternion.LookRotation(_target.position - transform.position);

        Vector3 eulerAngles = Quaternion.RotateTowards(transform.rotation, neededRotation, Time.deltaTime * _turnSpeed).eulerAngles;
        eulerAngles.x = 0f;
        eulerAngles.z = 0f;

        transform.rotation = Quaternion.Euler(eulerAngles);
    }

    private void Shoot()
    {
        Quaternion neededRotation = Quaternion.LookRotation(_target.position - transform.position);
        BulletAgent bullet = ObjectPool.Instance.BulletPool.Get();

        bullet.transform.position = Muzzle.position + Muzzle.forward;
        bullet.transform.rotation = neededRotation;
        bullet.Init(_gameManager);
        _gameManager.Levels.AddAgent(bullet);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _target = other.transform;
        }
    }
}
