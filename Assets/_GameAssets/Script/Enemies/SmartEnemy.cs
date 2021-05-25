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
            Vector3 target = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(target);
        }
        Move();
    }
    public override void Rotate()
    {
        if(distanceToPlayer <= distChase) return;
        base.Rotate();
    }
}
