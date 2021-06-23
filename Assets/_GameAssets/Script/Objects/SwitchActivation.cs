using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchActivation : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjectsToSwitch;
    bool triggered;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !triggered)
        {
            triggered = true;
            for (int i = 0; i < gameObjectsToSwitch.Length; i++)
            {
                gameObjectsToSwitch[i].SetActive(!gameObjectsToSwitch[i].activeInHierarchy);
            }
            Destroy(gameObject);
        }
    }
}
