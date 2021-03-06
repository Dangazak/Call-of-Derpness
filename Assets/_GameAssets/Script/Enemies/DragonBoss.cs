using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBoss : Enemy
{
    const string ANIM_AWAKE = "Awake", ANIM_ATTACKING = "Attacking", ANIM_DIE = "Die";
    [SerializeField] Animator animator;
    public static DragonBoss finalBoss;
    bool isAwake, turning, flyingOver, chasing;
    [SerializeField] float turningDistance, attackingDistance, rotationRate, speed, minAngleToPlayer, flyUpRotation;
    [SerializeField] GameObject hpBar;
    override public void Start()
    {
        base.Start();
        //if (finalBoss == null){
        finalBoss = this;
        /*}
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);*/
    }
    public override void Update()
    {
        base.Update();
        if (player == null)
            return;
        if (chasing)
        {
            if (distanceToPlayer < attackingDistance)
            {
                chasing = false;
                animator.SetTrigger(ANIM_ATTACKING);
            }
            else
            {
                LookAtPlayer();
                Move();
            }
        }
        else if (flyingOver)
        {
            if (distanceToPlayer > turningDistance)
            {
                flyingOver = false;
                turning = true;
            }
            else
            {
                Move();
            }
        }
        else if (turning)
        {
            if (IsAngleToPlayerTooBig())
            {
                Turn();
            }
            else
            {
                turning = false;
                chasing = true;
            }
        }
    }
    bool IsAngleToPlayerTooBig()
    {
        Vector3 directionToPlayer = new Vector3(player.transform.position.x - transform.position.x, 0, player.transform.position.y - transform.position.y);
        Vector3 xzForward = new Vector3(transform.forward.x, 0, transform.forward.z);
        float angleToPlayer = Vector3.Angle(directionToPlayer, xzForward);
        if (angleToPlayer > minAngleToPlayer)
            return true;
        return false;
    }
    void Turn()
    {
        transform.Rotate(transform.up * Time.deltaTime * rotationRate, Space.World);
        Move();
    }
    void LookAtPlayer()
    {
        Vector3 target = player.transform.position;
        transform.LookAt(target, Vector3.up);
    }
    public void Move()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
    }
    public override void ReceiveDamage(int dmg, Vector3 point, Vector3 normal)
    {
        if (isAwake)
            base.ReceiveDamage(dmg, point, normal);
    }
    public void EndAttack()
    {
        flyingOver = true;
        transform.Rotate(-flyUpRotation, 0, 0);
    }
    public void AwakeTheDragon()
    {
        FindObjectOfType<AudioManager>().ActivateFinalBossMusic();
        isAwake = true;
        chasing = true;
        animator.SetTrigger(ANIM_AWAKE);
        hpBar.SetActive(true);
    }
    public override void Death()
    {
        animator.SetTrigger(ANIM_DIE);
        isAwake = false;
        turning = false;
        flyingOver = false;
        chasing = false;
        GetComponent<Rigidbody>().isKinematic = false;
    }
    public override void Attack() { } //Attack handled by animation
}
