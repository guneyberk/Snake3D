using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    readonly int animHash_walk = Animator.StringToHash("Walk");
    readonly int animHash_turn = Animator.StringToHash("Turn");
    readonly int animHash_fire = Animator.StringToHash("Fire");
    readonly int animHash_shift = Animator.StringToHash("IsShiftPressed");
    Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        GetherInput();
    }
    void GetherInput()
    {
        _animator.SetFloat(animHash_walk, Input.GetAxis("Vertical"));
        _animator.SetFloat(animHash_turn, Input.GetAxis("Horizontal"));

        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetBool(animHash_fire, true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            FireMethod();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _animator.SetBool(animHash_shift, true);
            _animator.SetBool(animHash_fire, false);

        }
        else
            _animator.SetBool(animHash_shift, false);

    }

    IEnumerator FireMethod()
    {

        _animator.SetBool(animHash_fire, false);
        yield return new WaitForSeconds(5f);


    }
}


