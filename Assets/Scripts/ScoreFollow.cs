using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreFollow : MonoBehaviour
{
    [SerializeField] GameObject _player;
    private Vector3 offset = new Vector3(0,3.5f,0);

    void Update()
    {
        transform.position = _player.transform.position + offset;
    }
}
