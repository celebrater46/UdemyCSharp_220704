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
    public GameObject playerBullet;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        // Debug.Log(x);
        // Debug.Log(y);

        transform.position += new Vector3(x, y, 0) * Time.deltaTime * 4f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log("Pressed the space");
            Instantiate(playerBullet, playersGun.position, transform.rotation);
        }
    }
}
