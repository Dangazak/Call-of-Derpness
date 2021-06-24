using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Turns off any number of audio sources and turn one on when you enter a zone and swaps back once you leave
public class AmbientSoundsManager : MonoBehaviour
{
    [SerializeField] AudioSource[] audioArray;
    [SerializeField] AudioSource inSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < audioArray.Length; i++)
            {
                audioArray[i].Pause();
            }
            inSound.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < audioArray.Length; i++)
            {
                audioArray[i].UnPause();
            }
            inSound.Stop();
        }
    }
}
