using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float distance, damage;
    [SerializeField] float speed;
    [SerializeField] GameObject explosionPrefab;
    float travelDistance;
    private void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
        travelDistance += speed * Time.deltaTime;
        if (travelDistance >= distance)
        {
            Explode();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
            Explode();
    }
    void Explode()
    {
        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        //explosion.transform.localScale = transform.localScale;
        explosion.GetComponent<FireballExplosion>().damage = damage;
        Destroy(gameObject);
    }
}
