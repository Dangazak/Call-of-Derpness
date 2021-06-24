using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballWand : Weapon
{
    const string CHARGE = "Charge";
    [SerializeField] GameObject fireball; //, player;
    [SerializeField] float distance, minFireballSize, manaCost, maxChargeTime;
    GameManager gameManager;
    float charge, manaBuffer;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    override public void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (canShoot)
            {
                Charge();
            }
            //else
            //{
            //    PlayJammingSound();
            //}
        }
        else if (Input.GetButtonUp("Fire1") && charge > 0.1f)
        {
            Shoot();
        }
    }
    public void Charge()
    {
        if (charge >= maxChargeTime)
        {
            charge = maxChargeTime;
            return;
        }
        animator.SetBool(CHARGE, true);
        int manaUsed = (int)(Time.deltaTime * manaCost + manaBuffer);
        manaBuffer = (Time.deltaTime * manaCost + manaBuffer) - manaUsed;
        if (manaUsed > gameManager.GetMana())
            return;
        gameManager.UseMana(manaUsed);
        if (charge < maxChargeTime)
            charge += Time.deltaTime;
    }
    public override void Shoot()
    {
        PlayShootSound();
        GameObject fireballInstance = Instantiate(fireball, shootPoint.transform.position, shootPoint.transform.rotation); //player.transform.position, player.transform.rotation);
        float fireballScale = minFireballSize + (1 - minFireballSize) * charge / maxChargeTime;
        Fireball fireballScript = fireballInstance.GetComponent<Fireball>();
        fireballScript.damage = damage * fireballScale;
        fireballScript.distance = distance;
        animator.SetBool(CHARGE, false);
        charge = 0;
        manaBuffer = 0;
        canShoot = false;
        Invoke("ActivateShooting", cadence);
    }
}
