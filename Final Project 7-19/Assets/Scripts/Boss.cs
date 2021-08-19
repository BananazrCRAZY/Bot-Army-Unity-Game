using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int bossHealth = 100;
    public MeshRenderer shield;
    public MeshRenderer threeShield;
    public MeshRenderer twoShield;
    public MeshRenderer invertBoss;
    public MeshRenderer boss;
    public Text healthText;

    public int speed = 7;
    bool facingForward = true;
    public float minPos;
    public float maxPos;

    GameObject bullet;
    public GameObject speedBullet;
    public GameObject bossBullet;
    public BossBullet bb;
    public BossBullet speedbb;

    bool canShoot = true;
    Vector3 currentPos;
    public float timeBetweenShot = 9;
    private float timeUntilNextShot;
    public float shootLow;
    public float shootHigh;
    public bool lowHealth = false;

    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        bullet = bossBullet;
        //bullet = speedBullet;
        threeShield.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Update health
        healthText.text = "" + bossHealth + "";

        // Low health boost and form change
        if (bossHealth <= 75 && bossHealth > 50)
        {
            speed = 10;
            timeBetweenShot = 7.5f;
            NoMesh();
            twoShield.enabled = true;
        }
        else if (bossHealth <= 50 && bossHealth > 30)
        {
            timeBetweenShot = 5f;
            speed = 15;
            NoMesh();
            shield.enabled = true;
        }
        else if (bossHealth <= 30 && bossHealth > 15)
        {
            bullet = speedBullet;
            timeBetweenShot = 1f;
            speed = 23;
            NoMesh();
            boss.enabled = true;
        }
        else if (bossHealth <= 15 && bossHealth > 0)
        {
            lowHealth = true;
            timeBetweenShot = 0.4f;
            speed = 29;
            NoMesh();
            invertBoss.enabled = true;
        } 
        else if (bossHealth <= 0)
        {
            gameObject.SetActive(false);
            bossHealth = 0;
            wall.SetActive(false);
        }

        // Movement
        float minPosR = Random.Range(minPos, transform.position.x);
        float maxPosR = Random.Range(transform.position.x, maxPos);

        transform.Translate(Vector3.right * speed * Time.deltaTime);

        Vector3 rot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180, transform.rotation.eulerAngles.z);

        if (transform.position.x <= minPosR && facingForward == false)
        {
            transform.rotation = Quaternion.Euler(rot);
            facingForward = true;
            bb.goingLeft = false;
            speedbb.goingLeft = false;
        }
        if (transform.position.x >= maxPosR && facingForward == true)
        {
            transform.rotation = Quaternion.Euler(rot);
            facingForward = false;
            bb.goingLeft = true;
            speedbb.goingLeft = true;
        }

        //Shooting
        float shootRange = Random.Range(shootLow, shootHigh);

        if (facingForward)
        {
            rot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
        else
        {
            rot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180, transform.rotation.eulerAngles.z);
        }

        if (canShoot)
        {
            canShoot = false;
            timeUntilNextShot = Time.time + timeBetweenShot;

            currentPos = new Vector3(transform.position.x - 1, transform.position.y + shootRange, transform.position.z);
            Instantiate(bullet, currentPos, this.transform.rotation);
            if (lowHealth)
            {
                currentPos = new Vector3(transform.position.x - 1, transform.position.y + shootRange, transform.position.z);
                Instantiate(bullet, currentPos, this.transform.rotation);
            }
        }
        // SHooting timer
        if (Time.time > timeUntilNextShot)
        {
            canShoot = true;
        }
    }

    public void NoMesh()
    {
        threeShield.enabled = false;
        twoShield.enabled = false;
        shield.enabled = false;
        boss.enabled = false;
        invertBoss.enabled = false;
    }
}
