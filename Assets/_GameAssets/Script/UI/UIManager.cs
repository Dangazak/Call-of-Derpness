using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class UIManager : MonoBehaviour
{
    [SerializeField] Slider sliderHP;
    //[SerializeField] private GameObject botonReiniciar;
    [SerializeField] Text ammoText;
    [SerializeField] Text endText;
    [SerializeField] Text ammoTypeText;
    [SerializeField] GameObject endPanel;
    private GameManager gameManager;
    public bool manaActive;
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
        if (!manaActive)
            ammoText.text = gameManager.GetAmmo().ToString();
    }
    private void ManaUpdate()
    {
        if (manaActive)
            ammoText.text = gameManager.GetMana().ToString();
    }
    public void GameOverScreen()
    {
        endPanel.SetActive(true);
        UnlockMouse();
    }
    public void VictoryScreen()
    {
        endText.text = "V   I   C   T   O   R   Y";
        endPanel.SetActive(true);
        UnlockMouse();
    }
    public void ChangeToMana()
    {
        ammoTypeText.text = "M A N A";
        manaActive = true;
        ManaUpdate();
    }
    public void ChangeToAmmo()
    {
        ammoTypeText.text = "A M M O";
        manaActive = false;
        AmmoUpdate();
    }
    private void OnDisable()
    {
        gameManager.LifeUpdateEvent -= HealthBarUpdate;
        gameManager.AmmoUpdateEvent -= AmmoUpdate;
        gameManager.ManaUpdateEvent -= ManaUpdate;
    }
    private void UnlockMouse()
    {
        FirstPersonController fps = FindObjectOfType<FirstPersonController>();
        fps.mouseLookCustom.lockCursor = false;
    }
}
