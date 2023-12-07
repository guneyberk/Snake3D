using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] GameObject _enemyPrefab;
    List<GameObject> _bullets;
    List<GameObject> _enemyPool;
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
        GameObject tmp;
        GameObject tmpEnemy;
        for (int i = 0; i < _bulletCount; i++)
        {
            tmp = Instantiate(_bulletPrefab);
            tmp.SetActive(false);
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
}


