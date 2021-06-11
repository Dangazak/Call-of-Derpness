using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Slider sliderHP;
    //[SerializeField] private GameObject botonReiniciar;
    [SerializeField] Text ammoText;
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;

        gameManager.LifeUpdateEvent += HealthBarUpdate;
        gameManager.AmmoUpdateEvent += AmmoUpdate;
    }
    private void HealthBarUpdate()
    {
        sliderHP.value = (float)gameManager.GetLife() / (float)gameManager.GetMaxLife();
    }
    private void AmmoUpdate()
    {
        ammoText.text = gameManager.GetAmmo().ToString();
    }
}
