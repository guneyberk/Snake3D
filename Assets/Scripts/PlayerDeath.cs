using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    static public int _health;
    Animator _animator;
    public List<GameObject> _healthImg;

    private void Start()
    {
        _health = ScriptableObjectManager.instance.GetPlayerHealth();
        _animator = GetComponent<Animator>();

    }

    void Update()
    {
        if (_health <= 0)
        {
            _animator.SetBool("IsDeath", true);
            GetComponent<MouseFollow>().enabled = false;
            GetComponent<PlayerController>().enabled = false;
            Invoke("RestartScene", 5f);
        }
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

