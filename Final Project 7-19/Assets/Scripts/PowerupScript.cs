using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    public bool jumpBoost = false;
    public bool multiShot = false;
    public bool speed = false;
    public bool explosiveAmmo = false;
    public bool[] powerUps = new bool[4];

    public PlayerController pc;
    public ShooterCode shotC;
    // Start is called before the first frame update
    void Start()
    {
        powerUps[0] = jumpBoost;
        powerUps[1] = multiShot;
        powerUps[2] = speed;
        powerUps[3] = explosiveAmmo;

        powerUps[0] = false;
        powerUps[1] = false;
        powerUps[2] = false;
        powerUps[3] = false;
    }

    // Update is called once per frame
 
    void Update()
    {
        /*if (powerUps[0])
        {
            pc.jumpForce = 12f;
        } else if (powerUps[1])
        {
            shotC.timeBetweenShot = 0.45f;
        } else if (powerUps[2])
        {
            pc.speed = 20;
            shotC.timeBetweenShot = 0.27f;
        } else if (powerUps[0] == false && powerUps[1] == false && powerUps[2] == false)
        {
            pc.jumpForce = 5.5f;
            pc.speed = 7;
            shotC.timeBetweenShot = 0.5f;
        }*/
    }
    public void RandomPowerup()
    {
        powerUps[0] = false;
        powerUps[1] = false;
        powerUps[2] = false;
        powerUps[3] = false;
        powerUps[Random.Range(0, powerUps.Length)] = true;
    }
}

            /*pc.defaultForm.enabled = true;
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
            pc.shootingExplosiveForm.enabled = false;*/