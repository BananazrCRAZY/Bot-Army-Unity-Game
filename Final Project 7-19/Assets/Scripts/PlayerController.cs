using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int speed = 7;
    Rigidbody rb;
    public float jumpForce = 5.2f;
    public bool isDead = false;
    public GameObject gameover;

    public bool invicible = false;
    float invicibleTimer = 3f;
    public ParticleSystem invinPart;

    public bool jumpCheats = false;
    int jumpCounter = 0;

    public PowerupScript PowUp;

    public MeshRenderer defaultForm;
    public MeshRenderer jumpForm;
    public MeshRenderer shootingForm;
    public MeshRenderer defaultJumpForm;
    public MeshRenderer jumpJumpForm;
    public MeshRenderer shootingJumpForm;
    public MeshRenderer defaultSpeedForm;
    public MeshRenderer jumpSpeedForm;
    public MeshRenderer shootingSpeedForm;
    public MeshRenderer defaultMultiForm;
    public MeshRenderer jumpMultiForm;
    public MeshRenderer shootingMultiForm;
    public MeshRenderer defaultExplosiveForm;
    public MeshRenderer jumpExplosiveForm;
    public MeshRenderer shootingExplosiveForm;

    public GameoverScreen gos;
    //public SpawnPoint sp;
    public ShooterCode shot;
    public ButtonFunctions bf;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gos = GameObject.FindObjectOfType<GameoverScreen>();
        bf = GameObject.FindObjectOfType<ButtonFunctions>();
        gm = GameObject.FindObjectOfType<GameManager>();
        transform.position = gm.spawn;
        LosePowerUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (PowUp.powerUps[0])
        {
            jumpForce = 8f;
        }
        else if (PowUp.powerUps[1])
        {
            shot.timeBetweenShot = 0.4f;
        }
        else if (PowUp.powerUps[2])
        {
            speed = 15;
            shot.timeBetweenShot = 0.25f;
        } 
        else if (PowUp.powerUps[3])
        {
            shot.timeBetweenShot = 0.34f;
        }
        else
        {
            jumpForce = 5.2f;
            speed = 7;
            shot.timeBetweenShot = 0.5f;
        }

        if (transform.position.y <= -91)
        {
            GameOver();
        }

        if (isDead == false)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 180, transform.rotation.eulerAngles.z);
            }

            if (Input.GetButtonDown("Jump"))
            {
                if (jumpCounter < 2 || jumpCheats)
                {
                    if (PowUp.powerUps[0])
                    {
                        NoMesh();
                        jumpJumpForm.enabled = true;
                    } else if (PowUp.powerUps[1])
                    {
                        NoMesh();
                        jumpMultiForm.enabled = true;
                    } else if (PowUp.powerUps[2])
                    {
                        NoMesh();
                        jumpSpeedForm.enabled = true;
                    } else if (PowUp.powerUps[3])
                    {
                        NoMesh();
                        jumpExplosiveForm.enabled = true;
                    } else
                    {
                        NoMesh();
                        jumpForm.enabled = true;
                    }

                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    jumpCounter++;
                }
            }
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

    public void GameOver()
    {
        isDead = true;
        gameover.gameObject.SetActive(true);
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
            if (shot.canSwitchForm)
            {
                if (PowUp.powerUps[0])
                {
                    NoMesh();
                    defaultJumpForm.enabled = true;
                    jumpCounter = 0;
                }
                else if (PowUp.powerUps[1])
                {
                    NoMesh();
                    defaultMultiForm.enabled = true;
                    jumpCounter = 0;
                }
                else if (PowUp.powerUps[2])
                {
                    NoMesh();
                    defaultSpeedForm.enabled = true;
                    jumpCounter = 0;
                }
                else if (PowUp.powerUps[3])
                {
                    NoMesh();
                    defaultExplosiveForm.enabled = true;
                    jumpCounter = 0;
                }
                else
                {
                    NoMesh();
                    defaultForm.enabled = true;
                    jumpCounter = 0;
                }
            }
        }

        // Power Up
        if (collision.gameObject.CompareTag("Power Up"))
        {
            LosePowerUp();
            PowUp.RandomPowerup();
            Destroy(collision.gameObject);
        }

        // Next LvL
        /*if (collision.gameObject.CompareTag("Finish"))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }*/

        if (collision.gameObject.CompareTag("Ammo"))
        {
            shot.Ammo += 5;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Virus"))
        {
            Application.Quit();
        }
    }
    void LosePowerUp()
    {
        PowUp.powerUps[0] = false;
        PowUp.powerUps[1] = false;
        PowUp.powerUps[2] = false;
        PowUp.powerUps[3] = false;

        NoMesh();
        defaultForm.enabled = true;
    }
    
    public void NoMesh()
    {
        defaultForm.enabled = false;
        jumpForm.enabled = false;
        shootingForm.enabled = false;
        defaultJumpForm.enabled = false;
        jumpJumpForm.enabled = false;
        shootingJumpForm.enabled = false;
        defaultSpeedForm.enabled = false;
        jumpSpeedForm.enabled = false;
        shootingSpeedForm.enabled = false;
        defaultMultiForm.enabled = false;
        jumpMultiForm.enabled = false;
        shootingMultiForm.enabled = false;
        defaultExplosiveForm.enabled = false;
        jumpExplosiveForm.enabled = false;
        shootingExplosiveForm.enabled = false;
    }
}
