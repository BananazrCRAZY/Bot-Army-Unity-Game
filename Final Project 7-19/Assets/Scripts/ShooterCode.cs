using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShooterCode : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject explosiveBullet;
    public bool canShoot;
    public float timeBetweenShot = 0.5f;
    private float timeUntilNextShot;
    public PlayerController pc;
    public PowerupScript PowUp;

    // For default vs Shooting on platform
    float holdShooingForm = 0.1f;
    public float timeShootingForm;
    public bool canSwitchForm = true;

    public int Ammo = 5;
    // Start is called before the first frame update
    void Start()
    {
        timeShootingForm = Time.time * holdShooingForm;

        //Transform eBullet = Instantiate(explosiveBullet) as Transform;
        //Physics.IgnoreCollision(eBullet.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeUntilNextShot)
        {
            canShoot = true;
        }

        if (pc.isDead == false && Input.GetMouseButton(0) && canShoot && Ammo > 0)
        {
            if (PowUp.powerUps[1])
            {
                canShoot = false;
                timeUntilNextShot = Time.time + timeBetweenShot;

                pc.NoMesh();
                pc.shootingMultiForm.enabled = true;

                Vector3 currentPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
                Instantiate(Bullet, currentPos, this.transform.rotation);
                currentPos = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
                Instantiate(Bullet, currentPos, this.transform.rotation);
                currentPos = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
                Instantiate(Bullet, currentPos, this.transform.rotation);
                currentPos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
                Instantiate(Bullet, currentPos, this.transform.rotation);
                currentPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                Instantiate(Bullet, this.transform.position, this.transform.rotation);
                bool canSwitchForm = false;
                if (Ammo == 1)
                {
                    Ammo--;
                } 
                else
                {
                    Ammo -= 2;
                }
            }
            else if (PowUp.powerUps[2])
            {
                canShoot = false;
                timeUntilNextShot = Time.time + timeBetweenShot;

                pc.NoMesh();
                pc.shootingSpeedForm.enabled = true;

                Instantiate(Bullet, this.transform.position, this.transform.rotation);
                bool canSwitchForm = false;
                Ammo--;
            }
            else if (PowUp.powerUps[3])
            {
                canShoot = false;
                timeUntilNextShot = Time.time + timeBetweenShot;

                pc.NoMesh();
                pc.shootingExplosiveForm.enabled = true;

                Instantiate(explosiveBullet, this.transform.position, this.transform.rotation);
                bool canSwitchForm = false;
                if (Ammo == 1)
                {
                    Ammo--;
                }
                else
                {
                    Ammo -= 2;
                }
            }
            else if (PowUp.powerUps[0])
            {
                canShoot = false;
                timeUntilNextShot = Time.time + timeBetweenShot;

                pc.NoMesh();
                pc.shootingJumpForm.enabled = true;

                Instantiate(Bullet, this.transform.position, this.transform.rotation);
                bool canSwitchForm = false;
                Ammo--;
            } 
            else
            {
                canShoot = false;
                timeUntilNextShot = Time.time + timeBetweenShot;

                pc.NoMesh();
                pc.shootingForm.enabled = true;

                Instantiate(Bullet, this.transform.position, this.transform.rotation);
                bool canSwitchForm = false;
                Ammo--;
            }
        }

        if (Time.time > timeShootingForm)
        {
            bool canSwitchForm = true;
        }
    }
}
