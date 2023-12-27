using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectManager : MonoBehaviour
{
    public static ScriptableObjectManager instance;
    public ItemData itemData;

    private void Awake()
    {
            instance = this;
    }
    public void ChangeActiveWeaponData(ItemData newWeaponData)
    {
        itemData = newWeaponData;
    }
}
