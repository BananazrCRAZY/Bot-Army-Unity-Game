using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCode : MonoBehaviour
{
    public int speed = 15;
    public Score scoreCon;
    public Boss boss;
    // Start is called before the first frame update
    void Start()    
    {
        scoreCon = GameObject.FindObjectOfType<Score>();
        boss = GameObject.FindObjectOfType<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        Destroy(this.gameObject, 5.0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            gameObject.SetActive(false);
            scoreCon.score++;
        }
        if (other.gameObject.CompareTag("Platform"))
        {
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            boss.bossHealth--;
            gameObject.SetActive(false);
        }
    }
}
