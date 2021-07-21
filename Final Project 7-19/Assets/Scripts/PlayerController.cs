using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 5;
    public Rigidbody rb;
    float jumpForce = 6.0f;
    public bool isDead = false;
    public int score = 0;
    public Text scoreText;
    bool isGrounded;
    public float jumpHeight = 250f;
    public GameObject gameover;
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
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
            if (!isGrounded)
            {
                jumpForce -= Time.deltaTime;
            }
      
        }
        scoreText.text = "Score: " + score;
    }
    private void FixedUpdate()
    {
       if(!isGrounded && jumpForce > 0)
        {
            rb.AddForce(0, jumpHeight, 0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Platform")
        {
            jumpForce = 2.5f;
            isGrounded = true;
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
}
