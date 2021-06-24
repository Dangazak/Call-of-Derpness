using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls an arrow in the minimap that points at an objective
public class ObjectiveArrow : MonoBehaviour
{
    [SerializeField] Transform keyPosition;
    GameObject targetEnemy;
    void Update()
    {
        if (keyPosition != null)
        {
            LookAtTarget(keyPosition.position);
        }
        else if (targetEnemy == null)
        {
            targetEnemy = GameObject.FindGameObjectWithTag("Enemy");
            if (targetEnemy == null)
            {
                targetEnemy = FindObjectOfType<DragonBoss>().gameObject;
            }
            LookAtTarget(targetEnemy.transform.position);
        }
        else
        {
            LookAtTarget(targetEnemy.transform.position);
        }
    }
    void LookAtTarget(Vector3 target)
    {
        Vector3 pointToLooK = new Vector3(target.x, transform.position.y, target.z);
        transform.LookAt(pointToLooK);
    }
}
