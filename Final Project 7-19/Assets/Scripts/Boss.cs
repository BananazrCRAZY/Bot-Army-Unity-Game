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
    // Start is called before the first frame update
    void Start()
    {
        bullet = bossBullet;
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
            NoMesh();
            twoShield.enabled = true;
        }
        else if (bossHealth <= 50 && bossHealth > 30)
        {
            speed = 15;
            NoMesh();
            shield.enabled = true;
        }
        else if (bossHealth <= 30 && bossHealth > 15)
        {
            bullet = speedBullet;
            speed = 20;
            NoMesh();
            boss.enabled = true;
        }
        else if (bossHealth <= 15 && bossHealth > 0)
        {
            speed = 40;
            NoMesh();
            invertBoss.enabled = true;
        } 
        else if (bossHealth <= 0)
        {
            gameObject.SetActive(false);
            bossHealth = 0;
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
