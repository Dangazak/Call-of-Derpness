using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBossAnimationEvents : MonoBehaviour
{
    public void EndGame()
    {

    }
    public void EndAttack()
    {
        DragonBoss.finalBoss.EndAttack();
    }
}
