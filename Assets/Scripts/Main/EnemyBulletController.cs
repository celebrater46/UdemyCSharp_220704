using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
            transform.position -= new Vector3(0, Time.deltaTime * 3f, 0);
        }
    }
}
