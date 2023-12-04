using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] LayerMask _groundMask;
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
    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            var direction = position - transform.position;
            direction.y = 0;
            transform.forward = direction;
        }
    }

}
