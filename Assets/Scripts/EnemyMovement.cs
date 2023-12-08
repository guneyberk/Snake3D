using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    readonly int animHash = Animator.StringToHash("AttackPlayer");

    NavMeshAgent _enemyNavMesh;
    Animator _animator;

    GameObject _player;
    private void Start()
    {
        _player = GameObject.Find("Swat");
        _animator = GetComponent<Animator>();
        _enemyNavMesh = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        EnemyNavMesh();
    }
    void EnemyNavMesh()
    {
        _enemyNavMesh.SetDestination(_player.transform.position);
        if (Vector3.Distance(transform.position, _player.transform.position) <= 2f)
        {
            _animator.SetBool(animHash, true);
            _enemyNavMesh.enabled = false;
        }
        else
        {
            _enemyNavMesh.enabled = true;
            _animator.SetBool(animHash, false);
        }

    }
}
