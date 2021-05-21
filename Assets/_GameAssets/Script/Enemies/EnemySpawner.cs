using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    [Range(1, 15)]
    public float timeToSpawn;
    public int maxNumSpawns;
    private float delta = 0;
    private int spawnedEnemies = 0;

    //void Start()
    //{
    //    InvokeRepeating("funcion",tiempoInicial,tiempoEntreRepeticiones);
    //}
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Y)) { 
        //    Instantiate(enemy, transform.position, transform.rotation);
        //}
        delta += Time.deltaTime;

        if (delta >= timeToSpawn && spawnedEnemies < maxNumSpawns)
        {
            GameObject enemy = enemies[Random.Range(0, enemies.Length)];
            Instantiate(enemy, transform.position, transform.rotation);
            delta = 0;
            spawnedEnemies++;
        }
    }
}
