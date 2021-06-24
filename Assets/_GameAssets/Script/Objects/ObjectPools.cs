using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPools : MonoBehaviour
{
    GameObject[] objectPool;
    [SerializeField] GameObject objectPrefab;
    [SerializeField] int numberOfObjects;
    int activeIndex;
    // Start is called before the first frame update
    void Start()
    {
        objectPool = new GameObject[numberOfObjects];
        for (int i = 0; i < objectPool.Length; i++)
        {
            objectPool[i] = Instantiate(objectPrefab, transform.position, Quaternion.identity);
            objectPool[i].SetActive(false);
        }
    }
    public GameObject CreateObject(Vector3 position, Quaternion rotation)
    {
        GameObject tempGameObject = objectPool[activeIndex];
        tempGameObject.GetComponent<BallisticProyectile>().ResetProjectile();
        tempGameObject.transform.position = position;
        tempGameObject.transform.rotation = rotation;
        tempGameObject.SetActive(true);
        activeIndex++;
        if (activeIndex >= objectPool.Length)
            activeIndex = 0;
        return tempGameObject;
    }
}