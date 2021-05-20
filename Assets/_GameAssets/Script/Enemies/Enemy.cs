using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public GameObject prefabPSDamage;
    public GameObject prefabPSDeath;
    [HideInInspector]
    public float distanceToPlayer;
    [HideInInspector]
    public GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player == null){
            Debug.LogError("Player not found");
        }
    }
    public virtual void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
    }
    /// <summary>
    /// Determina si el player est� a la vista o no
    /// </summary>
    /// <returns></returns>
    public bool PlayerDetected()
    {
        //TODO Programar si est� viendo al Player
        return true;
    }


    /// <summary>
    /// Inflinge un da�o al enemigo
    /// </summary>
    public void ReceiveDamage()
    {
        //TODO sistema de part�culas, emitir un sonido, quitar salud, comprobar si ha muerto
    }

    /// <summary>
    /// Mata al enemigo
    /// </summary>
    public void Death()
    {
        //TODO sistema de part�culas, emitir un sonido y destruir el objeto
    }

    /// <summary>
    /// Ataque del enemigo
    /// </summary>
    public abstract void Attack();

}
