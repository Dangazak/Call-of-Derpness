using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour
{
    public Color targetColor;
    [Range(0,0.2f)]
    public float speed = 0;
    private Color initialColor;
    
    private Material myMaterial;

    private float delta = 0;
    private float r,g,b;
    void Start()
    {
        //myMaterial = GetComponent<Renderer>().sharedMaterial;//Obtener el material compartido y los cambios aplican a todos
        myMaterial = GetComponent<Renderer>().material;//Obtener el material propio del objeto y los cambios solo afectan a este
        initialColor = myMaterial.color;
        //myMaterial.color = new Color(0.8f,0.2f,0.2f);
        //myMaterial.SetColor("_Color", new Color(0.8f,0.2f,0.2f));//Es igual que la línea de arriba
        //myMaterial.SetFloat("_Amount",0.1f);
    }

    void Update()
    {
        delta = delta + Time.deltaTime * speed;
        r = Mathf.Lerp(initialColor.r, targetColor.r, delta);
        g = Mathf.Lerp(initialColor.g, targetColor.g, delta);
        b = Mathf.Lerp(initialColor.b, targetColor.b, delta);
        myMaterial.color = new Color(r,g,b);
    }
}
