using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public int EnemyHealth;
    public float Speed;
    public int Damage;
    public string EnemyName;
    public GameObject EnemyPrefab;
    public float spawnChance;
    [TextArea]
    public string Description;
}
