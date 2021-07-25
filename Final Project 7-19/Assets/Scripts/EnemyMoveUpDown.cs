using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveUpDown : MonoBehaviour
{
    public int speed = 13;
    bool moveUp = true;
    bool moveDown = false;
    public float minPos;
    public float maxPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moveUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        } else if (moveDown)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        if (transform.position.y <= minPos)
        {
            moveUp = true;
            moveDown = false;

        }

        if (transform.position.y >= maxPos)
        {
            moveUp = false;
            moveDown = true;
        }
    }
}
