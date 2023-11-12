using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    float _movementChunk = 0.5f;
    private bool _turnLeft;
    private bool _turnRight;

    public GameObject bodyPrefab;
    [SerializeField] List<GameObject> _bodyParts = new List<GameObject>();
    [SerializeField] List<Vector3> _positionHistory= new List<Vector3>();
    int gap = 1;

    private void Start()
    {
        InvokeRepeating("SnakeConstMovement", 0.1f, 0.2f);
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
       
    }

    void SnakeConstMovement()
    {

        if (_turnLeft)
        {
            transform.Rotate(0, -90, 0);
            _turnLeft = false;
        }
        if (_turnRight)
        {
            transform.Rotate(0, 90, 0);
            _turnRight = false;
        }
        transform.Translate(new Vector3(0, 0, _movementChunk));
        _positionHistory.Insert(0,transform.position);
        for (int i = 0; i <= _bodyParts.Count; i++)
        {
            Debug.Log(_positionHistory[i]);
            Vector3 point = _positionHistory[Mathf.Min(i*gap,_positionHistory.Count-1)];
            Vector3 moveDirection = point - _bodyParts[i].transform.position;
            _bodyParts[i].transform.position = point;

        
        }   
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            _turnLeft = true;
        if (Input.GetKeyDown(KeyCode.D))
            _turnRight = true;
    }

    private void GrowSnake()
    {
        GameObject body = Instantiate(bodyPrefab);
        _bodyParts.Add(body);
    }
}
