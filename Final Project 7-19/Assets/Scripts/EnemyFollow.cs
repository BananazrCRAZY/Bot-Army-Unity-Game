using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player;
    public float speed = 4;
    public float radius = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);

        if (Vector3.Distance(transform.position, player.transform.position) <= radius)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
