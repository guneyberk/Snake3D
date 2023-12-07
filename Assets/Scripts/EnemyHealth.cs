using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    readonly int animHash = Animator.StringToHash("IsDeath");
    int _health = 5;
    private bool gameOver;
    Animator _animator;
    private NavMeshAgent _navMeshAgent;
    private Collider _collider;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _collider = GetComponent<Collider>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            _health--;
        }
    }

    private void Update()
    {
        GameOver();
    }

    private void GameOver()
    {
        if (_health <= 0)
        {
            gameOver = true;
            _animator.SetBool(animHash, true);
            _navMeshAgent.enabled = false;
            _collider.enabled = false;
        }
    }

    void OnDeath()
    {
        EnemySpawner.enemyCount--;
        _health = 5;
        gameObject.SetActive(false);
        _navMeshAgent.enabled = true;
        _collider.enabled = true;
    }


}
