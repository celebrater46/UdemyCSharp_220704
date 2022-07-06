using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    public GameObject explosion;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, 0.5f, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Destroy!!");
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
