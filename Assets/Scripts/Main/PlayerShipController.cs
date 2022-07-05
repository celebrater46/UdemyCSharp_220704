using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
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
    }
}
