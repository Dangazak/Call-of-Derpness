using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveChanger : MonoBehaviour
{
    [Range(0,1f)]
    public float speed = 0;
    private Material myMaterial;
    private float delta = 0;
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        delta = delta + Time.deltaTime * speed;
        myMaterial.SetFloat("_Amount",delta);
    }
}
