using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickUp : MonoBehaviour
{
    [SerializeField] HealthManager healthManager;
    [SerializeField] int healAmount;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            healthManager.AddLife(healAmount);
            Destroy(gameObject);
        }
    }
}
