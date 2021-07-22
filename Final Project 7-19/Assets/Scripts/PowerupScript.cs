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

    public bool ultra = false;

    public PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        powerUps[0] = jumpBoost;
        powerUps[1] = multiShot;
        powerUps[2] = speed;
        powerUps[3] = explosiveAmmo;
    }

    // Update is called once per frame
 
    void Update()
    {
        if (jumpBoost)
        {
            pc.jumpForm.enabled = true;
            pc.defaultForm.enabled = false;
            pc.jumpForce = 8f;
        } else if (speed)
        {
            pc.speedForm.enabled = true;
            pc.defaultForm.enabled = false;
            pc.speed = 40;
        } else if (multiShot)
        {
            pc.multiForm.enabled = true;
            pc.defaultForm.enabled = false;
        } else if (explosiveAmmo)
        {
            pc.explosiveForm.enabled = true;
            pc.defaultForm.enabled = false;
        } else
        {
            pc.jumpForm.enabled = false;
            pc.speedForm.enabled = false;
            pc.multiForm.enabled = false;
            pc.explosiveForm.enabled = false;
            pc.defaultForm.enabled = true;

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
