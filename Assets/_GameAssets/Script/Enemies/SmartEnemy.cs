using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartEnemy : MobileEnemy
{

    [Range(1, 25)]
    public float distChase;
    [SerializeField] EnemyNavigation navigation;
    public override void Update()
    {
        base.Update();
        if (distanceToPlayer <= distChase)
        {
            navigation.SetChaseTarget(player);
        }
    }
}
