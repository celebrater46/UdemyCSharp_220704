using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour
{
    public GameObject explosion;
    private GameController gameController;
    
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -2.5)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position -= new Vector3(
                Mathf.Cos(Time.frameCount * 0.05f) * 0.01f, 
                Time.deltaTime, 
                0
                );
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(explosion, other.transform.position, transform.rotation);
            gameController.UnveilGameOverText();
        } 
        else if (other.CompareTag("Bullet"))
        {
            gameController.AddScore();
        }
        Debug.Log("Destroy!!");
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
