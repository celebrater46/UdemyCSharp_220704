using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    // To move the player...
    // 1. Get the keycode of the key a player input
    // 2. Change the player's position
    
    // To shoot a bullet...
    // 1. Create a bullet
    // 2. Add pattern how a bullet moves
    // 3. Create the fire point like a gun
    // 4. Create a bullet when pressed the key: Use "Instantiate()"
    
    public Transform playersGun; // Get the gun's location
    public GameObject playerBulletPrefab;
    public GameObject explosion;
    private GameController gameController;
    private AudioSource audioSource;
    public AudioClip shotSound;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shot();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        // Debug.Log(x);
        // Debug.Log(y);

        Vector3 nextPosition = transform.position + new Vector3(x, y, 0) * Time.deltaTime * 4f;
        nextPosition = new Vector3(
            Mathf.Clamp(nextPosition.x, -2.9f, 2.9f),
            Mathf.Clamp(nextPosition.y, -2f, 2f),
            nextPosition.z
            );
        
        // transform.position += new Vector3(x, y, 0) * Time.deltaTime * 4f;
        transform.position = nextPosition;
    }

    void Shot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log("Pressed the space");
            Instantiate(playerBulletPrefab, playersGun.position, transform.rotation);
            audioSource.PlayOneShot(shotSound);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            gameController.UnveilGameOverText();
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
