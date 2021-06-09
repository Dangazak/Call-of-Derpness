using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallisticProyectile : MonoBehaviour
{
    public int damage;
    public bool isSticky;

    private bool damgeActive = true;

    void OnCollisionEnter(Collision collision)
    {
        if (IsPlayer(collision.gameObject)) return;
        //Debug.Log(collision.gameObject.name);
        if (IsEnemy(collision.gameObject) && damgeActive)
        {
            collision.gameObject.GetComponent<Enemy>().ReceiveDamage(damage, collision.GetContact(0).point, collision.GetContact(0).normal);
            damgeActive = false;
        }
        if (isSticky)
        {
            gameObject.transform.SetParent(collision.gameObject.transform);
            gameObject.transform.rotation = Quaternion.LookRotation(collision.GetContact(0).normal);
            //gameObject.transform.Translate(Vector3.forward * -impactOffset);
            gameObject.transform.Rotate(0, 180, 0);
            gameObject.transform.position = collision.GetContact(0).point;
            Destroy(gameObject.GetComponentInParent<Rigidbody>());
            //Rigidbody rb = gameObject.GetComponentInParent<Rigidbody>();
            //rb.isKinematic = true;
            //rb.velocity = Vector3.zero;
            //gameObject.GetComponentInChildren<Collider>().enabled = false;
            //Debug.Log(collision.gameObject.name);
            Destroy(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private bool IsEnemy(GameObject candidate)
    {
        return candidate.CompareTag("Enemy");
    }
    private bool IsPlayer(GameObject candidate)
    {
        return candidate.CompareTag("Player");
    }
}
