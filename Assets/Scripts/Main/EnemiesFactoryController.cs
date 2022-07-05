using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesFactoryController : MonoBehaviour
{
    public GameObject enemiesShipPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemiesShipPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
