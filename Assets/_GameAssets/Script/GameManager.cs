using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    public delegate void DelegatedLifeUpdate();
    public event DelegatedLifeUpdate LifeUpdateEvent;
    public delegate void DelegatedAmmoUpdate();
    public event DelegatedAmmoUpdate AmmoUpdateEvent;
    public delegate void DelegatedManaUpdate();
    public event DelegatedManaUpdate ManaUpdateEvent;
    private int maxLife = 100, life = 100, ammo = 50, maxAmmo = 50, mana = 100, maxMana = 100, remainingEnemies;
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
            FindObjectOfType<UIManager>().GameOverScreen();
            Time.timeScale = 0;
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
    public int GetMana()
    {
        return mana;
    }
    public void AddMana(int Amount, bool display)
    {
        mana += Amount;
        if (mana > maxMana)
            mana = maxMana;
        if (ManaUpdateEvent != null && display)
            ManaUpdateEvent();
    }
    public void UseMana(int Amount)
    {
        mana -= Amount;
        if (mana < 0)
            mana = 0;
        if (ManaUpdateEvent != null)
            ManaUpdateEvent();
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
            DragonBoss.finalBoss.AwakeTheDragon();
    }
    public void AddEnemy()
    {
        remainingEnemies++;
    }
    public void Reset()
    {
        maxLife = 100;
        life = 100;
        ammo = 50;
        maxAmmo = 50;
        mana = 100;
        maxMana = 50;
        remainingEnemies = 0;
        Time.timeScale = 1;
    }
}
