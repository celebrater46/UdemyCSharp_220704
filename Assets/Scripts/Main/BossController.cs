using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public BossBulletController bossBulletPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        MultiShot(32, 0.5f);
        // Shot(Mathf.PI * 1.25f);
        // Shot(Mathf.PI * 1.5f);
        // Shot(Mathf.PI * 1.75f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shot(float angle, float speed)
    {
        BossBulletController bullet = Instantiate(bossBulletPrefab, transform.position, transform.rotation);
        bullet.Setting(angle, speed);
    }

    void MultiShot(int count, float speed)
    {
        // int bulletCount = 8;
        for (int i = 1; i <= count; i++)
        {
            float deg = Mathf.PI * (i / (count * 0.5f));
            Shot(deg, speed);
        }
    }
}
