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
        if (life > maxLife) life = maxLife;
        if (LifeUpdateEvent != null) LifeUpdateEvent();
    }
}
