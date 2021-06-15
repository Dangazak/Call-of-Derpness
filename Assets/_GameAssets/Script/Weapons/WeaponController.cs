using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    const string ANIM_LIGHTNING = "ChangeToLightning";
    const string ANIM_CROSSBOW = "ChangeToCrossbow";
    [SerializeField] GameObject[] weaponArray;
    int activeWeapon;
    [SerializeField] Animator handAndWeaponAnimator;
    [SerializeField] GameObject[] icons;
    [SerializeField] Weapon[] scripts;
    [SerializeField] bool[] availableWeapons;
    bool weaponChangeLock;
    [SerializeField] float weaponChangeCooldown;

    private void Update()
    {
        //if(Input.mouseScrollDelta)
        if (Input.GetKeyDown(KeyCode.Alpha1) && !weaponChangeLock && availableWeapons[0])
        {
            activeWeapon = 0;
            ActivateWeapon(activeWeapon);
            weaponChangeLock = true;
            StartCoroutine(UnlockWeaponChange());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && !weaponChangeLock && availableWeapons[1])
        {
            activeWeapon = 1;
            ActivateWeapon(activeWeapon);
            weaponChangeLock = true;
            StartCoroutine(UnlockWeaponChange());
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            activeWeaponUp();
            while (!availableWeapons[activeWeapon])
                activeWeaponUp();
            ActivateWeapon(activeWeapon);
            weaponChangeLock = true;
            StartCoroutine(UnlockWeaponChange());
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            activeWeaponDown();
            while (!availableWeapons[activeWeapon])
                activeWeaponDown();
            ActivateWeapon(activeWeapon);
            weaponChangeLock = true;
            StartCoroutine(UnlockWeaponChange());
        }


    }
    void ActivateWeapon(int weaponIndex)
    {
        for (int i = 0; i < weaponArray.Length; i++)
        {
            if (i == weaponIndex)
            {
                weaponArray[i].SetActive(true);
                icons[i].SetActive(true);
                scripts[i].enabled = true;
            }
            else
            {
                weaponArray[i].SetActive(false);
                icons[i].SetActive(false);
                scripts[i].enabled = false;
            }
        }
    }
    void activeWeaponUp()
    {
        activeWeapon++;
        if (activeWeapon >= weaponArray.Length)
            activeWeapon = 0;
    }
    void activeWeaponDown()
    {
        activeWeapon--;
        if (activeWeapon < 0)
            activeWeapon = weaponArray.Length - 1;
    }
    IEnumerator UnlockWeaponChange()
    {
        yield return new WaitForSeconds(weaponChangeCooldown);
        weaponChangeLock = false;
    }
}
