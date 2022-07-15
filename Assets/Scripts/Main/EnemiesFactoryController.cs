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
        // InvokeRepeating("Spawn", 2f, 1f);
        StartCoroutine(SpawnEnemy());
        // Invoke("CancelInvoke", 10);
        Invoke("SpawnBoss", 11);
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

    IEnumerator SpawnEnemy()
    {
        int x = 0;
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Spawn();
            if (x > 10)
            {
                yield break;
            }
            x++;
        }
        // for (int i = 0; i < 40; i++)
        // {
        //     yield return new WaitForSeconds(1f);
        //     Spawn();
        // }
        yield break;
    }

    void SpawnBoss()
    {
        Instantiate(bossPrefab, transform.position, transform.rotation);
    }
}
