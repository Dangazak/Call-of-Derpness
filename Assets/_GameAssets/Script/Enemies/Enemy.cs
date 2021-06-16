using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public GameObject prefabPSDamage;
    public GameObject prefabPSDeath;
    [HideInInspector]
    public float distanceToPlayer;
    [HideInInspector]
    public GameObject player;
    public GameManager gameManager;
    public HealthBarUpdater hpUpdater;

    void Awake()
    {
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player not found");
        }
    }
    public virtual void Start()
    {
        gameManager = GameManager.Instance;
    }
    public virtual void Update()
    {
        if (player != null)
            distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
    }
    /// <summary>
    /// Determina si el player est� a la vista o no
    /// </summary>
    /// <returns></returns>
    /*public bool PlayerDetected()
    {
        //TODO Programar si est� viendo al Player
        return true;
    }*/


    /// <summary>
    /// Inflinge un da�o al enemigo
    /// </summary>
    public virtual void ReceiveDamage(int dmg, Vector3 point, Vector3 normal)
    {
        health -= dmg;
        if (health <= 0)
        {
            Death();
        }
        else
        {
            if (point == null)
            {
                GameObject damagePS = Instantiate(prefabPSDamage, transform.position, transform.rotation);
                damagePS.transform.SetParent(gameObject.transform);
            }
            else
            {
                GameObject damagePS = Instantiate(prefabPSDamage, point, Quaternion.LookRotation(normal));
                damagePS.transform.SetParent(gameObject.transform);
            }

        }
        hpUpdater.UpdateHP();
    }

    /// <summary>
    /// Mata al enemigo
    /// </summary>
    public virtual void Death()
    {
        gameManager.EnemyKilled();
        Destroy(gameObject);
        Instantiate(prefabPSDeath, transform.position, transform.rotation);
    }

    /// <summary>
    /// Ataque del enemigo
    /// </summary>
    public abstract void Attack();

}
