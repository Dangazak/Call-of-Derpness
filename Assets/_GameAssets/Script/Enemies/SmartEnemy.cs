using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartEnemy : MobileEnemy
{
    
    [Range(1,25)]
    public float distChase;
    public override void Update()
    {
        base.Update();
        if(distanceToPlayer <= distChase){
            transform.LookAt(player.transform.position);
        }
        Move();
    }
    public override void Rotate()
    {
        if(distanceToPlayer <= distChase) return;
        base.Rotate();
    }
}
