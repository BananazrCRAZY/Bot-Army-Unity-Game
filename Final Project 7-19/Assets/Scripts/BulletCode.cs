using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCode : MonoBehaviour
{
    public float speed = 10;
    public Score scoreCon;
    // Start is called before the first frame update
    void Start()    
    {
        scoreCon = GameObject.FindObjectOfType<Score>();
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
    }
}
