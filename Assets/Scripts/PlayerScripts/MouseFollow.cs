using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] LayerMask _groundMask;
    [SerializeField] Transform _spawnPoint;
    float _bulletSpeed = 10000f;
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

        GameObject _bullets = ObjectPool.Instance.SpawnBullet();
        if (_bullets != null)
        {
            Vector3 dir = Aim();
            _bullets.SetActive(true);
            _bullets.transform.position = _spawnPoint.position;
            _bullets.transform.Rotate(dir);
            _bullets.GetComponent<Rigidbody>().velocity = dir.normalized * _bulletSpeed *Time.deltaTime;
        }

    }

}
