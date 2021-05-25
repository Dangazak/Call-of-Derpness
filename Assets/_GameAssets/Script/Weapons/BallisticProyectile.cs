using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallisticProyectile : MonoBehaviour
{
    public int damage;
    public bool isSticky;

    void OnCollisionEnter(Collision collision)
    {
        if(IsEnemy(collision.gameObject)){
            collision.gameObject.GetComponent<Enemy>().ReceiveDamage(damage, collision);
        }
        if(isSticky){
            gameObject.transform.SetParent(collision.gameObject.transform);
            Rigidbody rb = gameObject.GetComponentInParent<Rigidbody>();
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            Debug.Log(collision.gameObject.name);
            Destroy(this);
        }
        else{
            Destroy(gameObject);
        }
    }
    private bool IsEnemy(GameObject candidate){
        return candidate.CompareTag("Enemy");
    }
}
