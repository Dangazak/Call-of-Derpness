using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : Weapon
{
    const string SHOOT = "Shoot";
    [SerializeField] GameObject proyectilePrefab;
    [SerializeField] [Range(5, 50)] float shotForce;
    public override void Shoot()
    {
        canShoot = false;
        PlayShootSound();
        InstantiateBullet();
        animator.SetTrigger(SHOOT);
    }

    private void InstantiateBullet()
    {
        GameObject bullet = Instantiate(proyectilePrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("El proyectil debe tener un componente Rigidbody");
            return;
        }
        rb.AddForce(shootPoint.forward * shotForce);
    }
}
