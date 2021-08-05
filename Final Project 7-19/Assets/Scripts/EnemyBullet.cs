using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeT = 3f;
    public bool goingLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goingLeft)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        } else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        Destroy(gameObject, lifeT);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            gameObject.SetActive(false);
        }
    }
}
