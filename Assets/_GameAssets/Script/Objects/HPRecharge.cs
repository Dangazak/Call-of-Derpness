using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPRecharge : MonoBehaviour
{
    [SerializeField] private float rechargeRate = 10;
    private bool charging = false;
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    void Update()
    {
        if (charging)
        {
            int hp = (int)(rechargeRate * Time.deltaTime);
            if(hp < 1) hp=1;
            gameManager.Heal(hp);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) charging = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) charging = false;
    }
}
