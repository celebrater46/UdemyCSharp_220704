using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public BossBulletController bossBulletPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        int bulletCount = 8;
        for (int i = 1; i <= bulletCount; i++)
        {
            float deg = i / 4f;
            Shot(Mathf.PI * deg);
        }
        // Shot(Mathf.PI * 1.25f);
        // Shot(Mathf.PI * 1.5f);
        // Shot(Mathf.PI * 1.75f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shot(float angle)
    {
        BossBulletController bullet = Instantiate(bossBulletPrefab, transform.position, transform.rotation);
        bullet.Setting(angle);
    }
}
