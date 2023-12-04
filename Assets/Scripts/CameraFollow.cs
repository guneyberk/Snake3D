using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] Vector3 _offset;
    void LateUpdate()
    {
       Vector3 lerpedPos =Vector3.Lerp(transform.position, _player.transform.position,0.5f);
        transform.position = lerpedPos;
    }
}
