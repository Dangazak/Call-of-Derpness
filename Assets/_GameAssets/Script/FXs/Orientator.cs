using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientator : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private string targetTag;
    private void Start()
    {
        if (target == null && targetTag.Length == 0)
        {
            Debug.LogError("Debes introducir o target o targetTag");
            return;
        }
        if (target == null)
        {
            target = GameObject.FindWithTag(targetTag).transform;
        }
    }
    void Update()
    {
        Vector3 targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(targetPos);
    }
}
