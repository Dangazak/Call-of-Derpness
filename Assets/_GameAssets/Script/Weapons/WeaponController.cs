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
    bool weaponChangeLock;
    [SerializeField] float weaponChangeCooldown;

    private void Update()
    {
        //if(Input.mouseScrollDelta)
        if (Input.GetKeyDown(KeyCode.Alpha1) && !weaponChangeLock)
        {
            activeWeapon = 0;
            ActivateWeapon(activeWeapon);
            weaponChangeLock = true;
            StartCoroutine(UnlockWeaponChange());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && !weaponChangeLock)
        {
            activeWeapon = 1;
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
    IEnumerator UnlockWeaponChange()
    {
        yield return new WaitForSeconds(weaponChangeCooldown);
        weaponChangeLock = false;
    }
}
