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
        if (jumpBoost)
        {
            pc.jumpForce = 13f;
        } else if (speed)
        {
            pc.speed = 40;
        } else
        {
            pc.jumpForce = 5f;
            pc.speed = 20;
        }
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