using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public ItemData[] weapons;
    public Transform spawnPoint;
    int _currentWeaponIndex = 0;
    List<GameObject> weaponsIns = new List<GameObject>();
    private void Start()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weaponsIns.Add(Instantiate(weapons[i].weaponModel, spawnPoint));
            weaponsIns[i].transform.position = spawnPoint.position;
            weaponsIns[i].transform.rotation = spawnPoint.rotation;
            weaponsIns[i].SetActive(false);
        }
        SwitchWeapon(_currentWeaponIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchWeapon(2);
            
        }
    }

    private void SwitchWeapon(int newIndex)
    {
        if (newIndex >= 0 && newIndex < weapons.Length)
        {
            weaponsIns[_currentWeaponIndex].SetActive(false);

            
            weaponsIns[newIndex].SetActive(true);
            _currentWeaponIndex = newIndex;
            ScriptableObjectManager.instance.ChangeActiveWeaponData(weapons[newIndex]);
        }
    }

}
