using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    public GameObject lint;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) { 
            lint.SetActive(!lint.activeSelf); 
        }
    }
}
