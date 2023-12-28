using UnityEngine;

public class PlayerController : MonoBehaviour
{
    readonly int animHash_walk = Animator.StringToHash("Walk");
    readonly int animHash_turn = Animator.StringToHash("Turn");
    readonly int animHash_fire = Animator.StringToHash("Fire");
    readonly int animHash_shift = Animator.StringToHash("IsShiftPressed");
    Animator _animator;
    private float nextFireTime;

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

        if (Input.GetMouseButton(0))
        {
            if (PowerUp._isPowerUpActive)
            {
                _animator.SetFloat("speed", ScriptableObjectManager.instance.itemData.rateOfFire * 2f);
                _animator.SetBool(animHash_fire, true);

            }
            else
            {
                _animator.SetFloat("speed", ScriptableObjectManager.instance.itemData.rateOfFire);
                _animator.SetBool(animHash_fire, true);

            }

        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _animator.SetBool(animHash_shift, true);
            _animator.SetBool(animHash_fire, false);

        }
        else
            _animator.SetBool(animHash_shift, false);

    }

    void FireMethod()
    {

        _animator.SetBool(animHash_fire, false);


    }
}


