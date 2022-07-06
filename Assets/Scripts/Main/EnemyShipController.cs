using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyShipController : MonoBehaviour
{
    public GameObject explosion;
    public GameObject enemyBullet;
    private GameController gameController;
    private float offset;
    
    // Start is called before the first frame update
    void Start()
    {
        // offset = Random.Range(1f, 2f);
        offset = Random.Range(0, 2f * Mathf.PI);
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        InvokeRepeating("EnemyShot", Random.Range(1f, 3f), Random.Range(0.5f, 1f));
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
                Mathf.Cos(Time.frameCount * 0.01f + offset) * 0.01f, 
                Time.deltaTime * 2, 
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
            DestroyEnemy(other);
        } 
        else if (other.CompareTag("Bullet") && !other.CompareTag("EnemyBullet"))
        {
            gameController.AddScore();
            DestroyEnemy(other);
        }
        
    }

    void EnemyShot()
    {
        Instantiate(enemyBullet, transform.position, transform.rotation);
    }

    void DestroyEnemy(Collider2D other)
    {
        Debug.Log("Destroy!!");
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
