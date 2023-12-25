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
            weaponsIns[i] = Instantiate(weapons[i].weaponModel);
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
            weapons[_currentWeaponIndex].weaponModel.SetActive(false);


            weaponsIns[newIndex].SetActive(true);


            _currentWeaponIndex = newIndex;

            Debug.Log("Switched to" + weapons[newIndex].itemName);
        }
    }

}
