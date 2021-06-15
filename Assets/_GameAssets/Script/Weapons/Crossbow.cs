using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : Weapon
{
    const string SHOOT = "Shoot";
    [SerializeField] ObjectPools pool;
    [SerializeField] [Range(5, 50)] float shotForce;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    public override void Shoot()
    {
        if (gameManager.GetAmmo() > 0)
        {
            canShoot = false;
            PlayShootSound();
            InstantiateBullet();
            animator.SetTrigger(SHOOT);
            gameManager.UseAmmo();
        }
    }

    private void InstantiateBullet()
    {
        GameObject bullet = pool.CreateObject(shootPoint.position, shootPoint.rotation);//Instantiate(proyectilePrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("El proyectil debe tener un componente Rigidbody");
            return;
        }
        rb.AddForce(shootPoint.forward * shotForce);
    }
}
