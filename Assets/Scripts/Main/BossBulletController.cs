using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletController : MonoBehaviour
{
    // Start is called before the first frame update
    private float dx;
    private float dy;
    
    void Start()
    {
        
    }

    public void Setting(float angle, float speed)
    {
        // 2PI = 360 deg
        // PI = 180 deg
        // 0.5PI = 90 deg
        dx = Mathf.Cos(angle) * speed;
        dy = Mathf.Sin(angle) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(dx,  dy, 0) * Time.deltaTime;
    }
}
