using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBossAnimationEvents : MonoBehaviour
{
    public void EndGame()
    {
        FindObjectOfType<UIManager>().VictoryScreen();
        Time.timeScale = 0;
    }
    public void EndAttack()
    {
        DragonBoss.finalBoss.EndAttack();
    }
}
