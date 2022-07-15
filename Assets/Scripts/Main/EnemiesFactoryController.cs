using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesFactoryController : MonoBehaviour
{
    public GameObject enemiesShipPrefab;
    public GameObject bossPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 2f, 1f);
        // Invoke("CancelInvoke", 10);
        // Invoke("SpawnBoss", 4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-2.5f, 2.5f),
            transform.position.y,
            transform.position.z
            );
        Instantiate(
            enemiesShipPrefab, 
            spawnPosition, 
            transform.rotation
        );
    }

    void SpawnBoss()
    {
        Instantiate(bossPrefab, transform.position, transform.rotation);
    }
}
