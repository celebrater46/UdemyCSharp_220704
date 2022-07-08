using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public BossBulletController bossBulletPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        // MultiWayShot(32, 0.5f);
        // Shot(Mathf.PI * 1.25f);
        // Shot(Mathf.PI * 1.5f);
        // Shot(Mathf.PI * 1.75f);
        // MachineGun(8, 4);
        StartCoroutine(MachineGun(8, 4));
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

    void MultiWayShot(int count, float speed)
    {
        // int bulletCount = 8;
        for (int i = 1; i <= count; i++)
        {
            float deg = Mathf.PI * (i / (count * 0.5f));
            Shot(deg, speed);
        }
    }

    IEnumerator MachineGun(int ways, int times)
    {
        for (int i = 0; i < times; i++)
        {
            yield return new WaitForSeconds(0.3f);
            MultiWayShot(ways, 2f);
        }
    }
}
