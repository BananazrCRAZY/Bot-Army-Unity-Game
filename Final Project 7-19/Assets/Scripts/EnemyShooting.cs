using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    float shotTime = 0f;
    public GameObject enemyBullet;
    public float timeUntilNextShot = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shotTime += Time.deltaTime;
        if (shotTime > timeUntilNextShot)
        {
            Instantiate(enemyBullet, transform.position, transform.rotation);
            shotTime = 0;
        }
    }
}
