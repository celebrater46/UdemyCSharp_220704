using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public BossBulletController bossBulletPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(bossBulletPrefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
