using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTimeZone : MonoBehaviour
{
    [SerializeField] HealthManager healthManager;
    [SerializeField] int damageOverTime;
    void OnTriggerStay(Collider other)
    {
       if(other.gameObject.CompareTag("Player")){
           healthManager.RemoveLife(damageOverTime);
       }
    }
}
