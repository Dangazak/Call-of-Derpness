using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Solución muy poco eficiente. TODO-Mejorar.
*/
public class HealthBarUpdater : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Enemy enemy;
    void Update()
    {
        slider.value = (float)enemy.health / (float)enemy.maxHealth;
    }
}
