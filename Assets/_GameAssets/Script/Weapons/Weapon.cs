using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
   [SerializeField] int maxAmmo;
   [SerializeField] int Ammo;
   [SerializeField] int maxMagAmmo;
   [SerializeField] int magAmmo;
   [SerializeField] float damage;
   [SerializeField] float cad;
   [SerializeField] Animator animator;
   [SerializeField] bool auto = false;
   [SerializeField] Transform shootPoint;
   private AudioSource audioSource;
   [SerializeField] AudioClip shootSound;
   [SerializeField] AudioClip jammingSound;
   [SerializeField] AudioClip reloadSound;
   private bool canShoot = true;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();    
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (canShoot)
            {
                Shoot();
            } else
            {
                PlayJammingSound();
            }
        }
    }

    private void RestoreStatus()
    {
        canShoot = true;
    }

    private void PlayJammingSound()
    {
        audioSource.PlayOneShot(jammingSound);
    }
    private void PlayShootSound()
    {
        audioSource.PlayOneShot(shootSound);
    }
   public abstract void Shoot();
}
