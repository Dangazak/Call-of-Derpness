using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    public delegate void DelegatedLifeUpdate();
    public event DelegatedLifeUpdate LifeUpdateEvent;
    private int maxLife = 100;
    private int life = 100;
    public delegate void DelegatedAmmoUpdate();
    public event DelegatedLifeUpdate AmmoUpdateEvent;
    private int ammo = 50;
    private int maxAmmo = 50;
    private int remainingEnemies;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(gameObject); //Not recomended
    }
    public int GetLife()
    {
        return life;
    }
    public int GetMaxLife()
    {
        return maxLife;
    }
    public void TakeDamage(int Damage)
    {
        life -= Damage;
        if (life <= 0)
        {
            life = 0;
            //GameOver
        }
        if (LifeUpdateEvent != null) LifeUpdateEvent();
    }
    public void Heal(int Amount)
    {
        life += Amount;
        if (life > maxLife)
            life = maxLife;
        if (LifeUpdateEvent != null)
            LifeUpdateEvent();
    }
    public int GetAmmo()
    {
        return ammo;
    }
    public void AddAmmo(int Amount)
    {
        ammo += Amount;
        if (ammo > maxAmmo)
            ammo = maxAmmo;
        if (AmmoUpdateEvent != null)
            AmmoUpdateEvent();
    }
    public void UseAmmo()
    {
        ammo--;
        if (AmmoUpdateEvent != null)
            AmmoUpdateEvent();
    }
    public void EnemyKilled()
    {
        remainingEnemies--;
        if (remainingEnemies <= 0)
        {
            DragonBoss.finalBoss.GetComponent<DragonBoss>().AwakeTheDragon();
        }
    }
    public void AddEnemy()
    {
        remainingEnemies++;
    }
}
