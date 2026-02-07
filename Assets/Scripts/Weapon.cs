using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem _shotParticle;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _weaponForce;
    [SerializeField] private int _poolSize;

    private GameObject _currentBullet;
    private Queue<GameObject> _bulletPool = new Queue<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < _poolSize; ++i)
        {
            _currentBullet = Instantiate(_bulletPrefab);
            _currentBullet.SetActive(false);
            _bulletPool.Enqueue(_currentBullet);
        }
    }

    public void Create(Vector3 spawnPos)
    {
        _currentBullet = SpawnBullet();
        _currentBullet.transform.position = spawnPos;
    }

    public void Shoot(Vector3 shootDir)
    {
        if (_currentBullet.TryGetComponent(out Rigidbody bulletRb))
        {
            bulletRb.AddForce(shootDir * _weaponForce, ForceMode.Impulse);
            _shotParticle.Play();
        }
    }

    private GameObject SpawnBullet()
    {
        _currentBullet = _bulletPool.Dequeue();
        _currentBullet.SetActive(true);

        if (_currentBullet.TryGetComponent(out Rigidbody bulletRb))
        {
            bulletRb.linearVelocity = Vector3.zero;
            bulletRb.angularVelocity = Vector3.zero;
        }

        _bulletPool.Enqueue(_currentBullet);
        return _currentBullet;
    }
}
