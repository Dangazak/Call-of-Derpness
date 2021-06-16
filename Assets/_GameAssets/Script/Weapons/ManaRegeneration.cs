using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaRegeneration : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    private GameManager gameManager;
    bool chargeStopped;
    [SerializeField] float rechargeRate;
    float manaBuffer;
    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    void Update()
    {
        if (!chargeStopped)
        {
            manaBuffer += (rechargeRate * Time.deltaTime);
            int mana = (int)Mathf.Floor(manaBuffer);
            if (mana >= 1)
            {
                manaBuffer -= (float)mana;
                gameManager.AddMana(mana, uiManager.manaActive);
            }
        }
    }
    public void StopCharge()
    {
        chargeStopped = true;
    }
    public void StartCharge()
    {
        chargeStopped = false;
    }
}
