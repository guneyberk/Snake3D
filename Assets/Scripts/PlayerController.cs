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
        //Look();

    }
    void GetherInput()
    {
        //_input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
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
    private void FixedUpdate()
    {
        //Move();
    }
    /*private void Look()
    {
        if (_input != Vector3.zero)
        {
            var relative = (transform.position + _input.ToIso()) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed);
        }
    }
    void Move()
    {
        _rb.MovePosition(transform.position + (transform.up * _input.magnitude) * _speed * Time.deltaTime);*/
}


