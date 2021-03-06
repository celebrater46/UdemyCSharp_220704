using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject explosion;
    public GameObject explosionMini;
    private GameController gameController;
    public GameObject player;
    public BossBulletController bossBulletPrefab;
    private int bossHp = 20;
    // Start is called before the first frame update
    void Start()
    {
        // MultiWayShot(32, 0.5f);
        // Shot(Mathf.PI * 1.25f);
        // Shot(Mathf.PI * 1.5f);
        // Shot(Mathf.PI * 1.75f);
        // MachineGun(8, 4);
        // StartCoroutine(MachineGun(8, 4));
        player = GameObject.Find("PlayerShip");
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
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

    void AimShot(float speed)
    {
        float angle = GetAimAngle();
        Shot(angle, speed);
    }
    
    void MultiWayShot(int count, float speed)
    {
        // int bulletCount = 8;
        for (int i = 1; i <= count; i++)
        {
            float angle = Mathf.PI * (i / (count * 0.5f));
            Shot(angle, speed);
        }
    }

    void MultiWayAimShot(int count, float speed)
    {
        // int bulletCount = 8;
        for (int i = 1; i <= count; i++)
        {
            // float angle = Mathf.PI * (i / (count * 0.5f));
            float angle = (i - count / 2f - 0.5f) * ((Mathf.PI / 2f) / count);
            float aimAngle = GetAimAngle();
            Shot(aimAngle - angle, speed);
        }
    }

    private float GetAimAngle()
    {
        // Get relative position between the player and the boss
        Vector3 relativePosition = player.transform.position - transform.position;
        // Get direction of the player
        return Mathf.Atan2(relativePosition.y, relativePosition.x);
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
    
    IEnumerator AimMachineGun(int ways, int times, int speed, float wait)
    {
        for (int i = 0; i < times; i++)
        {
            yield return new WaitForSeconds(wait);
            // AimShot(speed);
            MultiWayAimShot(ways, speed);
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
            yield return MachineGun(6, 16, 5, 0.1f);
            yield return new WaitForSeconds(1f);
            yield return RollingGun(24, 8, 2, 0.01f, false);
            yield return new WaitForSeconds(1f);
            yield return AimMachineGun(6, 8, 5, 0.1f);
            yield return new WaitForSeconds(1f);
            yield return AimMachineGun(16, 3, 3, 0.2f);
            yield return new WaitForSeconds(1f);
            yield return AimMachineGun(32, 6, 2, 0.3f);
            yield return new WaitForSeconds(1f);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(explosion, other.transform.position, transform.rotation);
            gameController.UnveilGameOverText();
            // DestroyEnemy(other);
            Destroy(other.gameObject);
        } 
        else if (other.CompareTag("Bullet") 
                 && !other.CompareTag("EnemyBullet") 
                 && !other.CompareTag("Enemy"))
        {
            if (bossHp > 0)
            {
                bossHp -= 2;
                Instantiate(explosionMini, transform.position, transform.rotation);
            }
            else
            {
                gameController.AddScore(5000);
                DestroyEnemy(other);
            }
        }
        
    }
    
    void DestroyEnemy(Collider2D other)
    {
        Debug.Log("Destroy!!");
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        // Destroy(other.gameObject);
    }
}
