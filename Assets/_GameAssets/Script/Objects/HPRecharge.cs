using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPRecharge : MonoBehaviour
{
    [SerializeField] private float rechargeRate = 10;
    private bool charging = false;
    private GameManager gameManager;
    private float hpBuffer = 0;
    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    void Update()
    {
        if (charging)
        {
            hpBuffer += (rechargeRate * Time.deltaTime);
            int hp = (int)Mathf.Floor(hpBuffer);
            if (hp >= 1)
            {
                hpBuffer -= (float)hp;
                gameManager.Heal(hp);
            }
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
