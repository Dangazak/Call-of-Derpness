using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballExplosion : MonoBehaviour
{
    public float damage, maxSize;
    GameObject[] hittedEnemies;
    [SerializeField] int maxEnemies;
    int nextEnemyIndex;

    private void Start()
    {
        hittedEnemies = new GameObject[maxEnemies];
    }
    private void OnTriggerStay(Collider other)
    {
        if (IsEnemy(other.gameObject))
        {
            if (IsDamaged(other.gameObject))
                return;
            if (nextEnemyIndex >= hittedEnemies.Length)
                return;
            hittedEnemies[nextEnemyIndex] = other.gameObject;
            nextEnemyIndex++;
            CalculateDamage(other.gameObject, other.ClosestPointOnBounds(transform.position));
        }
    }
    void CalculateDamage(GameObject enemy, Vector3 impactPoint)
    {
        Vector3 distanceVector = impactPoint - transform.position;
        float distance = distanceVector.magnitude;
        if (distance <= 0.1f)
            enemy.GetComponentInParent<Enemy>().ReceiveDamage((int)damage, impactPoint, -Camera.main.transform.forward);
        else if (distance <= maxSize)
        {
            float distanceDamage = damage * (1 - distance / maxSize);
            enemy.GetComponentInParent<Enemy>().ReceiveDamage((int)distanceDamage, impactPoint, -Camera.main.transform.forward);
        }
    }
    bool IsDamaged(GameObject candidate)
    {
        for (int i = 0; i < hittedEnemies.Length; i++)
        {
            if (hittedEnemies[i] == candidate)
                return true;
        }
        return false;
    }
    private bool IsEnemy(GameObject candidate)
    {
        if (candidate.CompareTag("Enemy") || candidate.CompareTag("Boss"))
            return true;
        return false;
    }
}
