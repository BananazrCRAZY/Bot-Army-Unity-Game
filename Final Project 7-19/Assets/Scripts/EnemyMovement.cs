using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
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
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        Vector3 rot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180, transform.rotation.eulerAngles.z);

        if (transform.position.x <= minPos && facingForward == false)
        {
            transform.rotation = Quaternion.Euler(rot);
            facingForward = true;
        }
        if (transform.position.x >= maxPos && facingForward == true)
        {
            transform.rotation = Quaternion.Euler(rot);
            facingForward = false;
        }
    }
}
