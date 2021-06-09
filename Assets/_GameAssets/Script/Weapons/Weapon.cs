using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int maxAmmo;
    public int Ammo;
    //[SerializeField] int maxMagAmmo;
    //[SerializeField] int magAmmo;
    public float damage;
    public float cadence;
    public Animator animator;
    //[SerializeField] bool auto = false;
    public Transform shootPoint;
    public AudioSource audioSource;
    public AudioClip shootSound;
    public AudioClip jammingSound;
    public AudioClip reloadSound;
    public bool canShoot = false;

    void Awake()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    public virtual void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (canShoot)
            {
                Shoot();
            }
            else
            {
                PlayJammingSound();
            }
        }
    }
    public void PlayJammingSound()
    {
        audioSource.PlayOneShot(jammingSound);
    }
    public void PlayShootSound()
    {
        audioSource.PlayOneShot(shootSound);
    }
    public void PlayReloadSound()
    {
        audioSource.PlayOneShot(reloadSound);
    }
    public void ActivateShooting()
    {
        canShoot = true;
    }
    public abstract void Shoot();
}
