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
    /*void ResetObjectWithRigidbody(GameObject objectToReset)
    {
        Rigidbody rb = objectToReset.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.Log("Rigidbody not found, plunger needs Rigidbody");
            return;
        }
        rb.velocity = Vector3.zero;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.isKinematic = false;
        objectToReset.SetActive(true);
    }*/
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