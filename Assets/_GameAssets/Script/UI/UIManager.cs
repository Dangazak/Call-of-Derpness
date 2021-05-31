using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider sliderHP;
    //[SerializeField] private GameObject botonReiniciar;
    //[SerializeField]
    //private Text municion;
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;

        gameManager.LifeUpdateEvent += HealthBarUpdate;
    }
    private void HealthBarUpdate(){
        sliderHP.value = (float) gameManager.GetLife() / (float) gameManager.GetMaxLife();
    }
}
