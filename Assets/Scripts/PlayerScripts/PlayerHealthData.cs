using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthData : MonoBehaviour
{
    public float displayValue;
    public PlayerData playerData;
    private void UpdateHealthBar()
    {
        displayValue = playerData.health;
    }
}
