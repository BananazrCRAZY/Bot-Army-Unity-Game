using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    bool jumpBoost = false;
    bool multiShot = false;
    bool speed = false;
    bool explosiveAmmo = false;
    bool[] powerUps = new bool[4];
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
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindPowerup();
        }
    }
    public void FindPowerup()
    {
        powerUps[Random.Range(0, powerUps.Length)] = true;
    }
}
