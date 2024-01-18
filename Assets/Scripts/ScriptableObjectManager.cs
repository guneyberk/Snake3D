using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectManager : MonoBehaviour
{
    public static ScriptableObjectManager instance;
    public ItemData itemData;
    public PlayerData playerData;
    public List<EnemyData> enemyData;

    private void Awake()
    {
        instance = this;
    }
    public void ChangeActiveWeaponData(ItemData newWeaponData)
    {
        itemData = newWeaponData;
    }

    public EnemyData EnemyChoose()
    {
        float randomVal = Random.value;
        foreach (EnemyData enemy in enemyData)
        {
            if (randomVal < enemy.spawnChance)
            {

                return enemy;
            }

        }

        return null;
    }

    public int GetPlayerHealth()
    {
        return playerData.health;
    }
}

