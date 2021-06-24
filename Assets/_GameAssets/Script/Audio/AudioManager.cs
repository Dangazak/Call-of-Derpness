using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Stores audio clips that can be called from other scripts
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] AudioClip finalBossMusic, keyMusic, gameOverMusic, victoryMusic, ammoSound, changeWeaponSound;
    public void ActivateFinalBossMusic()
    {
        musicAudioSource.clip = finalBossMusic;
        musicAudioSource.loop = true;
        musicAudioSource.Play();
    }
    public void PlayKeyMusic()
    {
        audioSource.PlayOneShot(keyMusic);
    }
    public void PlayGameOverMusic()
    {
        musicAudioSource.PlayOneShot(gameOverMusic);
    }
    public void PlayVictoryMusic()
    {
        musicAudioSource.PlayOneShot(victoryMusic);
    }
    public void PlayAmmoSound()
    {
        audioSource.PlayOneShot(ammoSound);
    }
    public void PlayChangeWeaponSound()
    {
        audioSource.PlayOneShot(changeWeaponSound);
    }
}
