using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoRecharge : MonoBehaviour
{
    [SerializeField] private int rechargeAmount = 25;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.AddAmmo(rechargeAmount);
            Destroy(gameObject);
        }
    }
}
