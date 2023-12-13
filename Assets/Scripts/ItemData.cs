using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public string itemName;
    public GameObject weaponModel;
    [TextArea] 
    public string description;
    public int startingAmmo;
    public int startingCondition;

}
