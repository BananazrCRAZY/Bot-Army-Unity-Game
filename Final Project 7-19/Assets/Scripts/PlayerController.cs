using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int speed = 20;
    Rigidbody rb;
    float jumpForce = 7f;
    public bool isDead = false;
    public int score = 0;
    public Text scoreText;
    public GameObject gameover;

    public bool jumpCheats = false;
    int jumpCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);

                //(For ex)transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);

                //(For ex)transform.Translate(Vector3.back * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime);

                //(For ex) transform.Translate(Vector3.right * speed * Time.deltaTime);
                //transform.Rotate(new Vector3(0, rotSped, 0) * Time.deltaTime * -1);
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);

                //(For ex)transform.Translate(Vector3.left * speed * Time.deltaTime);
                //transform.Rotate(new Vector3(0, rotSped, 0) * Time.deltaTime);
            }
            if (Input.GetButtonDown("Jump"))
            {
                if (jumpCounter < 2 || jumpCheats)
                {
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    jumpCounter++;
                }
            }

            scoreText.text = "Score: " + score;
        } 
    }

    void GameOver()
    {
        isDead = true;
        gameover.active = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            jumpCounter = 0;
        }
    }
}
