using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 _input;
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _speed = 5f;
    [SerializeField] float _turnSpeed = 360;
    [SerializeField] Animator _animator;
    private void Update()
    {
        GetherInput();
    }
    void GetherInput()
    {
        _animator.SetFloat("Walk", Input.GetAxis("Vertical"));
        _animator.SetFloat("Turn", Input.GetAxis("Horizontal"));

        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetBool("Fire", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            _animator.SetBool("Fire", false);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _animator.SetBool("IsShiftPressed", true);
            _animator.SetBool("Fire", false);

        }
        else
            _animator.SetBool("IsShiftPressed", false);

    }
}


