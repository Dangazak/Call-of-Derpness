using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Slider sliderHP;
    //[SerializeField] private GameObject botonReiniciar;
    [SerializeField] Text ammoText;
    [SerializeField] Text endText;
    [SerializeField] Text ammoTypeText;
    [SerializeField] GameObject endPanel;
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;

        gameManager.LifeUpdateEvent += HealthBarUpdate;
        gameManager.AmmoUpdateEvent += AmmoUpdate;
        gameManager.ManaUpdateEvent += ManaUpdate;
    }
    private void HealthBarUpdate()
    {
        sliderHP.value = (float)gameManager.GetLife() / (float)gameManager.GetMaxLife();
    }
    private void AmmoUpdate()
    {
        ammoText.text = gameManager.GetAmmo().ToString();
    }
    private void ManaUpdate()
    {
        ammoText.text = gameManager.GetMana().ToString();
    }
    public void GameOverScreen()
    {
        endPanel.SetActive(true);
    }
    public void VictoryScreen()
    {
        endText.text = "V   I   C   T   O   R   Y";
        endPanel.SetActive(true);
    }
    public void ChangeToMana()
    {
        ammoTypeText.text = "M A N A";
        ManaUpdate();
    }
    public void ChangeToAmmo()
    {
        ammoTypeText.text = "A M M O";
        AmmoUpdate();
    }
    private void OnDisable()
    {
        gameManager.LifeUpdateEvent -= HealthBarUpdate;
        gameManager.AmmoUpdateEvent -= AmmoUpdate;
        gameManager.ManaUpdateEvent -= ManaUpdate;
    }
}
