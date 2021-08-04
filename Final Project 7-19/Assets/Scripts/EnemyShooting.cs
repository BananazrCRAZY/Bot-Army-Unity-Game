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
        Vector3 bull = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);

        shotTime += Time.deltaTime;
        if (shotTime > timeUntilNextShot)
        {
            Instantiate(enemyBullet, bull, transform.rotation);
            shotTime = 0;
        }
    }
}
