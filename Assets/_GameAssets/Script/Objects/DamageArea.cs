using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    [SerializeField] private float damageOverTime = 10;
    private bool charging = false;
    private GameManager gameManager;
    private float damageBuffer = 0;
    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    void Update()
    {
        if (charging)
        {
            damageBuffer += (damageOverTime * Time.deltaTime);
            int damage = (int)Mathf.Floor(damageBuffer);
            if (damage >= 1)
            {
                damageBuffer -= (float)damage;
                gameManager.TakeDamage(damage);
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
