using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bossBullet;
    int bossHealth = 30;
    public MeshRenderer shield;
    public MeshRenderer boss;
    public Text health;

    public int speed = 13;
    bool facingForward = true;
    public float minPos;
    public float maxPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update health
        health.text = "" + bossHealth + "";

        // Low health boost
        if (bossHealth <= 15)
        {
            speed = 16;
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
        }
        if (transform.position.x >= maxPosR && facingForward == true)
        {
            transform.rotation = Quaternion.Euler(rot);
            facingForward = false;
        }
    }
}
