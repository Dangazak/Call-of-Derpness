using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colision comienza");
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Colision se mantiene");
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Colision sale");
    }
}
