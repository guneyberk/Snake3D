using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    int _health = 5;
    private bool gameOver;
    Animator _animator;


    private void Start()
    {
        _animator = GetComponent<Animator>();
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
            _animator.SetBool("IsDeath", gameOver);
            transform.GetComponent<NavMeshAgent>().enabled = false;
        }
    }

    void OnDeath()
    {
        EnemySpawner.enemyCount--;
        Debug.Log(EnemySpawner.enemyCount);
        _health = 5;
        gameObject.GetComponent<NavMeshAgent>().gameObject.SetActive(true);
        gameObject.SetActive(false);
    }


}
