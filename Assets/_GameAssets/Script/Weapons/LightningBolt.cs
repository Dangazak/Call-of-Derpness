using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBolt : Weapon
{
    const string SHOOT = "Shoot";
    [SerializeField] GameObject lightning;
    [SerializeField] GameObject impactFX;
    [SerializeField] Transform lightningStartPoint;
    [SerializeField] Transform startPoint;
    [SerializeField] Transform endPoint;
    [SerializeField] float distance;
    [SerializeField] LayerMask layerMask;
    Ray ray;
    RaycastHit hitInfo;
    GameManager gameManager;
    Vector3 impact;
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
                Shoot();
            }
            //else
            //{
            //    PlayJammingSound();
            //}
        }
    }
    public override void Shoot()
    {
        if (gameManager.GetAmmo() > 0)//Change to mana
        {
            canShoot = false;
            PlayShootSound();
            ray = new Ray(shootPoint.position, shootPoint.forward);
            if (Physics.Raycast(ray, out hitInfo, distance, layerMask))
            {
                impact = shootPoint.position + shootPoint.forward * hitInfo.distance;
                ActivateLightning(impact, true);
                if (IsEnemy(hitInfo.collider.gameObject))
                {
                    hitInfo.collider.gameObject.GetComponent<Enemy>().ReceiveDamage(damage, impact, hitInfo.normal);
                }
            }
            else
            {
                impact = shootPoint.position + shootPoint.forward * distance;
                ActivateLightning(impact, false);
            }
            //animator.SetTrigger(SHOOT); //Add animation
            gameManager.UseAmmo();//Change to mana
        }
    }

    private void ActivateLightning(Vector3 impactPoint, bool impacted)
    {
        endPoint.position = impactPoint;
        startPoint.position = lightningStartPoint.position;
        lightning.SetActive(true);
        if (impacted)
            Instantiate(impactFX, endPoint.position, Quaternion.LookRotation(-shootPoint.forward));
        Invoke("ActivateShooting", cadence);
    }
    private bool IsEnemy(GameObject candidate)
    {
        return candidate.CompareTag("Enemy");
    }
}
