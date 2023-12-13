using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerData PlayerData;
    void Update()
    {
        PlayerData.currentPosition = transform.position;
    }
}
