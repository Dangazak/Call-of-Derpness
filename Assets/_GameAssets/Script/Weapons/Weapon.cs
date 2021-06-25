using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    //public int maxAmmo;
    //public int Ammo;
    //[SerializeField] int maxMagAmmo;
    //[SerializeField] int magAmmo;
    public int damage;
    public float cadence;
    public Animator animator;
    //[SerializeField] bool auto = false;
    public Transform shootPoint;
    public AudioSource audioSource;
    public AudioClip shootSound;
    public AudioClip jammingSound;
    public AudioClip reloadSound;
    public bool canShoot = false;
    public bool jamSoundJustPlayed;

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
        if (!jamSoundJustPlayed)
        {
            jamSoundJustPlayed = true;
            audioSource.PlayOneShot(jammingSound);
            StartCoroutine(UnlockJamSound());
        }
    }
    public IEnumerator UnlockJamSound()
    {
        yield return new WaitForSeconds(1f);
        jamSoundJustPlayed = false;
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
    public void DeactivateShooting()
    {
        canShoot = false;
    }
    public abstract void Shoot();
}
