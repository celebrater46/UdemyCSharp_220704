using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.001f, 0);
        if(transform.position.y < -4.74f)
        {
            transform.position = new Vector3(0, 4.74f, 0);
        }
    }
}
