using UnityEngine;

public class PowerUp : MonoBehaviour
{

    readonly int animHash = Animator.StringToHash("speed");
    public static bool _isPowerUpActive;
    private float _PowerUpTimer = 0.0f;
    private float _PowerUpTime = 5.0f;

    [SerializeField] Material _PlayerMaterial;
    private Color colorEnd = Color.black;
    private Color colorStart = Color.yellow;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Collectible")
        {
            collision.gameObject.SetActive(false);
            _isPowerUpActive = true;
            _PowerUpTimer = Time.time + _PowerUpTime;
            float lerp = Mathf.PingPong(Time.time, _PowerUpTimer) / _PowerUpTimer;
            _PlayerMaterial.color = Color.Lerp(colorStart, colorEnd, 1f);



        }

    }
    private void Update()
    {
        if (Time.time > _PowerUpTimer && _isPowerUpActive)
        {
            PowerUpCooldown();
        }
    }

    public void PowerUpCooldown()
    {
        _animator.SetFloat(animHash, 1f);
        _isPowerUpActive = false;
        _PlayerMaterial.color = colorStart;
    }
}
