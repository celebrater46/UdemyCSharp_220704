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
        // StartCoroutine(MachineGun(8, 4));
        StartCoroutine(BossBehavior());
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
    
    IEnumerator RollingShot(int count, float speed, float wait, bool isReverse)
    {
        for (int i = 1; i <= count; i++)
        {
            float deg = Mathf.PI * (i / (count * 0.5f));
            Shot(isReverse ? deg : -deg, speed);
            yield return new WaitForSeconds(wait);
        }
    }

    IEnumerator MachineGun(int ways, int times, int speed, float wait)
    {
        for (int i = 0; i < times; i++)
        {
            yield return new WaitForSeconds(wait);
            MultiWayShot(ways, speed);
        }
    }
    
    IEnumerator RollingGun(int ways, int times, int speed, float wait, bool isReverse)
    {
        for (int i = 0; i < times; i++)
        {
            yield return new WaitForSeconds(wait);
            yield return RollingShot(ways, speed, wait, isReverse);
        }
    }

    IEnumerator BossBehavior()
    {
        // init
        while (transform.position.y > 1f)
        {
            transform.position -= new Vector3(0, 1, 0) * Time.deltaTime;
            yield return null;
        }
        
        while (true)
        {
            Debug.Log("Hello World");
            yield return RollingGun(24, 8, 2, 0.01f, true);
            yield return RollingGun(24, 8, 2, 0.01f, false);
            yield return new WaitForSeconds(1f);
            yield return MachineGun(6, 8, 5, 0.1f);
            yield return new WaitForSeconds(1f);
            yield return MachineGun(16, 3, 3, 0.2f);
            yield return new WaitForSeconds(1f);
            yield return MachineGun(32, 6, 2, 0.3f);
            yield return new WaitForSeconds(1f);
        }
    }
}
