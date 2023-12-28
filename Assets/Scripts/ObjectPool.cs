using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] GameObject _explosionPrefab;
    [SerializeField] GameObject _enemyPrefab;
    List<GameObject> _bullets;
    List<GameObject> _enemyPool;
    List<GameObject> _explosion;
    int _bulletCount = 30;
    int _enemyCount = 100;

    private void Awake()
    {

        Instance = this;

    }
    private void Start()
    {

        _bullets = new List<GameObject>();
        _enemyPool = new List<GameObject>();
        _explosion = new List<GameObject>();
        GameObject tmp;
        GameObject tmpexplosion;
        GameObject tmpEnemy;
        for (int i = 0; i < _bulletCount; i++)
        {
            tmp = Instantiate(_bulletPrefab);
            tmpexplosion = Instantiate(_explosionPrefab);
            tmp.SetActive(false);
            tmpexplosion.SetActive(false);
            _explosion.Add(tmpexplosion);
            _bullets.Add(tmp);
        }
        for (int i = 0; i < _enemyCount; i++)
        {
            tmpEnemy = Instantiate(_enemyPrefab);
            tmpEnemy.SetActive(false);
            _enemyPool.Add(tmpEnemy);
        }
        
    }

    public GameObject SpawnBullet()
    {
        for (int i = 0; i < _bullets.Count; i++)
        {
            if (!_bullets[i].activeInHierarchy)
            {
                return _bullets[i];
            }

        }
        return null;
    }

    public GameObject SpawnEnemies()
    {
        for (int i = 0; i < _enemyPool.Count; i++)
        {
            if (!_enemyPool[i].activeInHierarchy)
            {
                return _enemyPool[i];
            }

        }
        return null;
    }
    
    public GameObject SpawnExplosion()
    {
        for (int i = 0; i < _bullets.Count; i++)
        {
            if (!_explosion[i].activeInHierarchy)
            {
                return _explosion[i];
            }

        }
        return null;
    }

    
}


