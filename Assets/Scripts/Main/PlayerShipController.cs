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
    private AudioSource audioSource;
    public AudioClip shotSound;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

        transform.position += new Vector3(x, y, 0) * Time.deltaTime * 4f;
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
}
