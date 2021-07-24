using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    float holdShooingForm = 0.18f;
    public float timeShootingForm;
    public bool canSwitchForm = true;

    //public int Ammo = 20;
    // Start is called before the first frame update
    void Start()
    {
        timeShootingForm = Time.time * holdShooingForm;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeUntilNextShot)
        {
            canShoot = true;
        }
        
        if (PowUp.powerUps[0] == false && PowUp.powerUps[1] == false && PowUp.powerUps[2] == false && PowUp.powerUps[3] == false && Input.GetMouseButton(0) && canShoot && pc.isDead == false)
        {
            timeBetweenShot = 0.5f;
            canShoot = false;
            timeUntilNextShot = Time.time + timeBetweenShot;
            pc.defaultForm.enabled = false;
            pc.jumpForm.enabled = false;
            pc.shootingForm.enabled = true;
            pc.defaultJumpForm.enabled = false;
            pc.jumpJumpForm.enabled = false;
            pc.shootingJumpForm.enabled = false;
            pc.defaultSpeedForm.enabled = false;
            pc.jumpSpeedForm.enabled = false;
            pc.shootingSpeedForm.enabled = false;
            pc.defaultMultiForm.enabled = false;
            pc.jumpMultiForm.enabled = false;
            pc.shootingMultiForm.enabled = false;
            pc.defaultExplosiveForm.enabled = false;
            pc.jumpExplosiveForm.enabled = false;
            pc.shootingExplosiveForm.enabled = false;
            Instantiate(Bullet, this.transform.position, this.transform.rotation);
            bool canSwitchForm = false;
            // Ammo--;
            // Debug.Log(Ammo + " ammo left");
        } else if (PowUp.powerUps[1] && Input.GetMouseButton(0) && canShoot && pc.isDead == false)
        {
            timeBetweenShot = 0.45f;
            canShoot = false;
            timeUntilNextShot = Time.time + timeBetweenShot;
            pc.defaultForm.enabled = false;
            pc.jumpForm.enabled = false;
            pc.shootingForm.enabled = false;
            pc.defaultJumpForm.enabled = false;
            pc.jumpJumpForm.enabled = false;
            pc.shootingJumpForm.enabled = false;
            pc.defaultSpeedForm.enabled = false;
            pc.jumpSpeedForm.enabled = false;
            pc.shootingSpeedForm.enabled = false;
            pc.defaultMultiForm.enabled = false;
            pc.jumpMultiForm.enabled = false;
            pc.shootingMultiForm.enabled = true;
            pc.defaultExplosiveForm.enabled = false;
            pc.jumpExplosiveForm.enabled = false;
            pc.shootingExplosiveForm.enabled = false;
            Vector3 currentPos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            Instantiate(Bullet, currentPos, this.transform.rotation);
            currentPos = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            Instantiate(Bullet, currentPos, this.transform.rotation);
            currentPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Instantiate(Bullet, this.transform.position, this.transform.rotation);
            bool canSwitchForm = false;
        } else if (PowUp.powerUps[2] && Input.GetMouseButton(0) && canShoot && pc.isDead == false)
        {
            timeBetweenShot = 0.27f;
            canShoot = false;
            timeUntilNextShot = Time.time + timeBetweenShot;
            pc.defaultForm.enabled = false;
            pc.jumpForm.enabled = false;
            pc.shootingForm.enabled = false;
            pc.defaultJumpForm.enabled = false;
            pc.jumpJumpForm.enabled = false;
            pc.shootingJumpForm.enabled = false;
            pc.defaultSpeedForm.enabled = false;
            pc.jumpSpeedForm.enabled = false;
            pc.shootingSpeedForm.enabled = true;
            pc.defaultMultiForm.enabled = false;
            pc.jumpMultiForm.enabled = false;
            pc.shootingMultiForm.enabled = false;
            pc.defaultExplosiveForm.enabled = false;
            pc.jumpExplosiveForm.enabled = false;
            pc.shootingExplosiveForm.enabled = false;
            Instantiate(Bullet, this.transform.position, this.transform.rotation);
            bool canSwitchForm = false;
        } else if (PowUp.powerUps[3] && Input.GetMouseButton(0) && canShoot && pc.isDead == false)
        {
            canShoot = false;
            timeUntilNextShot = Time.time + timeBetweenShot;
            pc.defaultForm.enabled = false;
            pc.jumpForm.enabled = false;
            pc.shootingForm.enabled = false;
            pc.defaultJumpForm.enabled = false;
            pc.jumpJumpForm.enabled = false;
            pc.shootingJumpForm.enabled = false;
            pc.defaultSpeedForm.enabled = false;
            pc.jumpSpeedForm.enabled = false;
            pc.shootingSpeedForm.enabled = false;
            pc.defaultMultiForm.enabled = false;
            pc.jumpMultiForm.enabled = false;
            pc.shootingMultiForm.enabled = false;
            pc.defaultExplosiveForm.enabled = false;
            pc.jumpExplosiveForm.enabled = false;
            pc.shootingExplosiveForm.enabled = true;
            Instantiate(explosiveBullet, this.transform.position, this.transform.rotation);
            bool canSwitchForm = false;
        } else if (PowUp.powerUps[0] && Input.GetMouseButton(0) && canShoot && pc.isDead == false)
        {
            canShoot = false;
            timeUntilNextShot = Time.time + timeBetweenShot;
            pc.defaultForm.enabled = false;
            pc.jumpForm.enabled = false;
            pc.shootingForm.enabled = false;
            pc.defaultJumpForm.enabled = false;
            pc.jumpJumpForm.enabled = false;
            pc.shootingJumpForm.enabled = true;
            pc.defaultSpeedForm.enabled = false;
            pc.jumpSpeedForm.enabled = false;
            pc.shootingSpeedForm.enabled = false;
            pc.defaultMultiForm.enabled = false;
            pc.jumpMultiForm.enabled = false;
            pc.shootingMultiForm.enabled = false;
            pc.defaultExplosiveForm.enabled = false;
            pc.jumpExplosiveForm.enabled = false;
            pc.shootingExplosiveForm.enabled = false;
            Instantiate(Bullet, this.transform.position, this.transform.rotation);
            bool canSwitchForm = false;
        }

        if (Time.time > timeShootingForm)
        {
            bool canSwitchForm = true;
        }
    }
}
