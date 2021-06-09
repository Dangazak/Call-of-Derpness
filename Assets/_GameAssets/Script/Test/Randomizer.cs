using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    [SerializeField] GameObject[] objectArray;
    [SerializeField] float timeToCreate;
    void Start()
    {
        InvokeRepeating("CreateObject", 0, timeToCreate);
    }

    void CreateObject()
    {
        int randomIndex = Random.Range(0, objectArray.Length);
        Instantiate(objectArray[randomIndex], transform.position, transform.rotation); //Quaternion.identity (if you want to use the rotation of the prefab)
    }
}
