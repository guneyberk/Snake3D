using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] GameObject _enemyPrefab;
    List<GameObject> _bullets;
    int _bulletCount = 30;

    private void Awake()
    {

        Instance = this;

    }
    private void Start()
    {

        _bullets = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < _bulletCount; i++)
        {
            tmp = Instantiate(_bulletPrefab);
            tmp.SetActive(false);
            _bullets.Add(tmp);
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
}


