using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterCode : MonoBehaviour
{
    public GameObject Bullet;
    public bool canShoot;
    public float timeBetweenShot = 0.5f;
    private float timeUntilNextShot;
    public PlayerController pc;

    public int Ammo = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeUntilNextShot)
        {
            canShoot = true;
        }
        
        if (Input.GetMouseButton(0) && canShoot && pc.isDead == false && Ammo > 0)
        {
            canShoot = false;
            timeUntilNextShot = Time.time + timeBetweenShot;
            Instantiate(Bullet, this.transform.position, this.transform.rotation);
            Ammo--;
            Debug.Log(Ammo + " ammo left");
        }
    }
}
