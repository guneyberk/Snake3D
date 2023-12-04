using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 5;
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
            health--;
        }
    }

    private void Update()
    {
        GameOver();
    }

    private void GameOver()
    {
        if (health <= 0)
        {
            gameOver = true;

            _animator.SetBool("IsDeath", gameOver);
            transform.GetComponent<NavMeshAgent>().enabled = false;
            
        }
    }


}
