using Cinemachine;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    [SerializeField] Camera _camera;

    [SerializeField] LayerMask _groundMask;
    [SerializeField] Transform _spawnPoint;
    float _bulletSpeed = 10000f;
    public CinemachineVirtualCamera virtualCamera;
    public int pelletCount = 5;
    public float spreadAngle = 20f;
    private void Awake()
    {
       CinemachineComposer composer = virtualCamera.GetComponent<CinemachineComposer>();
        composer.

    }
    private void Update()
    {
        Aim();
    }
    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, _groundMask))
        {
            return (success: true, position: hitInfo.point);
        }
        else
        {
            return (success: false, position: Vector3.zero);
        }
    }
    private Vector3 Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            var direction = position - transform.position;
            direction.y = 0;
            transform.forward = direction;
            return direction;
        }
        return Vector3.zero;



    }

    void Fire()
    {

        if (ScriptableObjectManager.instance.itemData.itemName == "Shotgun")
        {
            for (int i = 0; i < pelletCount; i++)
            {

                GameObject _bulletsShotgun = ObjectPool.Instance.SpawnBullet();
                if (_bulletsShotgun != null)
                {
                    Vector3 dirShotgun = Aim();
                    _bulletsShotgun.SetActive(true);
                    _bulletsShotgun.transform.position = _spawnPoint.position;
                    _bulletsShotgun.GetComponent<Rigidbody>().velocity = (dirShotgun.normalized) * _bulletSpeed * Time.deltaTime;
                }
            }

        }

        if (ScriptableObjectManager.instance.itemData.itemName == "AR24") { }
        if (ScriptableObjectManager.instance.itemData.itemName == "Sniper") { }
        GameObject _bullets = ObjectPool.Instance.SpawnBullet();
        if (_bullets != null)
        {

            Vector3 dir = Aim();
            _bullets.SetActive(true);
            _bullets.transform.position = _spawnPoint.position;
            _bullets.transform.Rotate(dir);
            _bullets.GetComponent<Rigidbody>().velocity = dir.normalized * _bulletSpeed * Time.deltaTime;
        }
    }
}


