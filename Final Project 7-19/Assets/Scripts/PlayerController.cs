using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int speed = 20;
    public int powerSpeed = 40;
    Rigidbody rb;
    public float jumpForce = 5f;
    public bool isDead = false;
    public int score = 0;
    public Text scoreText;
    public GameObject gameover;

    public bool invicible = false;
    float invicibleTimer = 3f;
    public ParticleSystem invinPart;

    public bool jumpCheats = false;
    int jumpCounter = 0;

    public PowerupScript PowUp;

    public MeshRenderer defaultForm;
    public MeshRenderer jumpForm;
    public MeshRenderer speedForm;
    public MeshRenderer multiForm;
    public MeshRenderer explosiveForm;
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
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }

            // Turn other way
            if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(0, 180, 0);
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

        // Invicible Timer
        if (invicible)
        {
            invicibleTimer -= Time.deltaTime;
            float invinCountdown = Mathf.Floor(invicibleTimer);
            invinPart.Play();
            if (invicibleTimer <= 0)
            {
                invicible = false;
            }
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
            if (invicible)
            {
                Debug.Log("Can't touch ME!");
            } else
            {
                if (PowUp.powerUps[0] == true || PowUp.powerUps[1] == true || PowUp.powerUps[2] == true || PowUp.powerUps[3] == true)
                {
                    LosePowerUp();
                    invicible = true;
                } else
                {
                    GameOver();
                }
            }
        }
    }

    // jump fix
    private void OnCollisionEnter(Collision collision)
    {
        // Double Jump
        if (collision.gameObject.CompareTag("Platform"))
        {
            jumpCounter = 0;
        }

        // Power Up
        if (collision.gameObject.CompareTag("Power Up"))
        {
            PowUp.RandomPowerup();
        }

        // Next LvL
        if (collision.gameObject.CompareTag("Finish"))
        {

        }
    }
    void LosePowerUp()
    {
        PowUp.powerUps[0] = false;
        PowUp.powerUps[1] = false;
        PowUp.powerUps[2] = false;
        PowUp.powerUps[3] = false;
    }
}
