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
            //Destroy(gameObject);
            //Instantiate(prefabPSDeath,transform.position,transform.rotation);
            Death();
            gameManager.TakeDamage(damage);
        }
    }
    public virtual void Rotate()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hitInfo;
        Physics.Raycast(ray, out hitInfo);
        transform.up = hitInfo.normal;
        int det = Random.Range(0, 100);
        int sign = det > 50 ? 1 : -1;
        transform.Rotate(0, Random.Range(minAngle, maxAngle) * sign, 0);
    }
    public override void Start()
    {
        base.Start();
        InvokeRepeating("Rotate", timeToRotation, timeToRotation);
    }
    public void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    public override void Update()
    {
        base.Update();
        Attack();
    }
}
