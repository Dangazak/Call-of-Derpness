using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnTimer : MonoBehaviour
{
    [SerializeField] float timeToDeactivate;
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("Deactivate", timeToDeactivate);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
