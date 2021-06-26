using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoofyEnemy : MobileEnemy
{
    public override void Update()
    {
        base.Update();
        Rotate();
    }
}
