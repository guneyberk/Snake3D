using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullets : MonoBehaviour
{
    [SerializeField] Transform _spawnPoint;
    float _bulletSpeed = 10f;

    void Fire()
    {

        GameObject _bullets = ObjectPool.Instance.SpawnBullet();
        if (_bullets != null)
        {
            _bullets.SetActive(true);
            _bullets.transform.position = _spawnPoint.position;
            _bullets.GetComponent<Rigidbody>().velocity = Vector3.forward * _bulletSpeed;
        }

    }

    

}
