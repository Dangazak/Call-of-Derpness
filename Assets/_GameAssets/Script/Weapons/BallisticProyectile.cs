using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallisticProyectile : MonoBehaviour
{
    public int damage;
    public bool isSticky;

    public bool damgeActive = true;

    void OnCollisionEnter(Collision collision)
    {
        if (IsPlayer(collision.gameObject)) return;
        if (IsEnemy(collision.gameObject) && damgeActive)
        {
            collision.gameObject.GetComponentInParent<Enemy>().ReceiveDamage(damage, collision.GetContact(0).point, collision.GetContact(0).normal);
            damgeActive = false;
            gameObject.SetActive(false);
            return;
        }
        if (isSticky)
        {
            if (IsEnemy(collision.gameObject))
                return;
            gameObject.transform.SetParent(collision.gameObject.transform);
            gameObject.transform.rotation = Quaternion.LookRotation(collision.GetContact(0).normal);
            gameObject.transform.Rotate(0, 180, 0);
            gameObject.transform.position = collision.GetContact(0).point;
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.collisionDetectionMode = CollisionDetectionMode.Discrete;
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            gameObject.GetComponent<Collider>().enabled = false;
        }
        else
        {
            gameObject.SetActive(false);
        }
        damgeActive = false;
    }
    private bool IsEnemy(GameObject candidate)
    {
        if (candidate.CompareTag("Enemy") || candidate.CompareTag("Boss"))
            return true;
        return false;
    }
    private bool IsPlayer(GameObject candidate)
    {
        return candidate.CompareTag("Player");
    }
    public void ResetProjectile()
    {
        damgeActive = true;
        transform.SetParent(null);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.isKinematic = false;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        GetComponent<Collider>().enabled = true;
    }
}
