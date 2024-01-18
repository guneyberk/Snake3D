using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    readonly int animHash = Animator.StringToHash("IsDeath");
    int _health;
    Animator _animator;
    private NavMeshAgent _navMeshAgent;
    private Collider _collider;
    public ScriptableObjectManager scriptableObjectManager;
    public UnityEvent playerDamageEvent;
    private int _damage;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _collider = GetComponent<Collider>();
        _health = ScriptableObjectManager.instance.enemyData[Random.Range(0,2)].EnemyHealth;
        GetComponent<Animator>().SetFloat("EnemySpeed", ScriptableObjectManager.instance.enemyData[Random.Range(0, 2)].Speed);
        _damage = ScriptableObjectManager.instance.enemyData[Random.Range(0, 2)].Damage;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            _health -= ScriptableObjectManager.instance.itemData.damage;
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
            
            _animator.SetBool(animHash, true);
            _navMeshAgent.enabled = false;
            _collider.enabled = false;
        }
    }

    void OnDeath()
    {
        ScoreTextUpdate.score += 5;
        EnemySpawner.enemyCount--;
        _health = ScriptableObjectManager.instance.enemyData[Random.Range(0, 2)].EnemyHealth;
        gameObject.SetActive(false);
        _navMeshAgent.enabled = true;
        _collider.enabled = true;
    }

    public void PlayerHit()
    {
        PlayerDeath._health -= _damage;
    }

}
