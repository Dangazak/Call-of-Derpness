using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    const string ANIM_LIGHTNING = "ChangeToLightning";
    const string ANIM_FIREBALL = "ChangeToFireball";
    const string ANIM_CROSSBOW = "ChangeToCrossbow";
    int activeWeapon;
    [SerializeField] Animator handAndWeaponAnimator;
    [SerializeField] GameObject[] icons;
    [SerializeField] Weapon[] weaponScripts;
    [SerializeField] bool[] availableWeapons;
    bool weaponChangeLock;
    [SerializeField] float weaponChangeCooldown;
    [SerializeField] UIManager uiManager;

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
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f && !weaponChangeLock)
        {
            ActiveWeaponUp();
            while (!availableWeapons[activeWeapon])
                ActiveWeaponUp();
            ActivateWeapon(activeWeapon);
            weaponChangeLock = true;
            StartCoroutine(UnlockWeaponChange());
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && !weaponChangeLock)
        {
            ActiveWeaponDown();
            while (!availableWeapons[activeWeapon])
                ActiveWeaponDown();
            ActivateWeapon(activeWeapon);
            weaponChangeLock = true;
            StartCoroutine(UnlockWeaponChange());
        }


    }
    void ActivateWeapon(int weaponIndex)
    {
        for (int i = 0; i < weaponScripts.Length; i++)
        {
            if (i == weaponIndex)
            {
                icons[i].SetActive(true);
                weaponScripts[i].enabled = true;
            }
            else
            {
                icons[i].SetActive(false);
                weaponScripts[i].enabled = false;
            }
        }
        if (weaponIndex == 0)
        {
            handAndWeaponAnimator.SetTrigger(ANIM_CROSSBOW);
            uiManager.ChangeToAmmo();
        }
        else if (weaponIndex == 1)
        {
            handAndWeaponAnimator.SetTrigger(ANIM_LIGHTNING);
            uiManager.ChangeToMana();
        }
        else if (weaponIndex == 2)
        {
            handAndWeaponAnimator.SetTrigger(ANIM_FIREBALL);
            uiManager.ChangeToMana();
        }
    }
    void ActiveWeaponUp()
    {
        activeWeapon++;
        if (activeWeapon >= weaponScripts.Length)
            activeWeapon = 0;
    }
    void ActiveWeaponDown()
    {
        activeWeapon--;
        if (activeWeapon < 0)
            activeWeapon = weaponScripts.Length - 1;
    }
    IEnumerator UnlockWeaponChange()
    {
        yield return new WaitForSeconds(weaponChangeCooldown);
        weaponChangeLock = false;
    }
}
