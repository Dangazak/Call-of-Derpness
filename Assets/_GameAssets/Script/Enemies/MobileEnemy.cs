using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MobileEnemy : Enemy
{
    [Range(0, 360)]
    public float minAngle;
    [Range(0, 360)]
    public float maxAngle;
    [Range(1, 10)]
    public float speed;
    [Range(1, 5)]
    public float timeToRotation;
    [Range(1, 5)]
    public float distExplo;
    public int damage;
    public override void Attack()
    {
        if (distanceToPlayer <= distExplo)
        {
            gameManager.TakeDamage(damage);
            Death();
        }
    }
    public virtual void Rotate()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hitInfo;
        Physics.Raycast(ray, out hitInfo, 1);
        transform.up = hitInfo.normal;
    }
    public override void Start()
    {
        base.Start();
        gameManager.AddEnemy();
        //InvokeRepeating("Rotate", timeToRotation, timeToRotation);
    }
    /*public void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }*/
    public override void Update()
    {
        base.Update();
        Attack();
        StayOnBounds();
    }
    void StayOnBounds()
    {
        if (transform.position.x > 500 || transform.position.x < 0 || transform.position.y < 12 || transform.position.z > 500 || transform.position.z < 0)
            transform.position = new Vector3(317, 32, 314);
    }
}
