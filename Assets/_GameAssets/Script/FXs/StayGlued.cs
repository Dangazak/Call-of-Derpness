using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayGlued : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        transform.SetParent(collision.gameObject.transform);
        GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        Debug.Log(transform.parent.name);
    }
}
