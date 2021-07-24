using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int speed = 13;
    public int powerSpeed = 26;
    Rigidbody rb;
    public float jumpForce = 8f;
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
    public SpawnPoint sp;

    public ShooterCode shot;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gos = GameObject.FindObjectOfType<GameoverScreen>();

        //sp = GameObject.FindObjectOfType<SpawnPoint>();
        //transform.position = sp.transform.position;

        defaultForm.enabled = true;

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

        Debug.Log(PowUp.powerUps[3]);
    }

    // Update is called once per frame
    void Update()
    {
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

            // Turn other way
            /*if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(0, 180, 0);
            }*/

            if (Input.GetButtonDown("Jump"))
            {
                if (jumpCounter < 2 || jumpCheats)
                {
                    if (PowUp.powerUps[0])
                    {
                        defaultForm.enabled = false;
                        jumpForm.enabled = false;
                        shootingForm.enabled = false;
                        defaultJumpForm.enabled = false;
                        jumpJumpForm.enabled = true;
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
                    } else if (PowUp.powerUps[1])
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
                        jumpMultiForm.enabled = true;
                        shootingMultiForm.enabled = false;
                        defaultExplosiveForm.enabled = false;
                        jumpExplosiveForm.enabled = false;
                        shootingExplosiveForm.enabled = false;
                    } else if (PowUp.powerUps[2])
                    {
                        defaultForm.enabled = false;
                        jumpForm.enabled = false;
                        shootingForm.enabled = false;
                        defaultJumpForm.enabled = false;
                        jumpJumpForm.enabled = false;
                        shootingJumpForm.enabled = false;
                        defaultSpeedForm.enabled = false;
                        jumpSpeedForm.enabled = true;
                        shootingSpeedForm.enabled = false;
                        defaultMultiForm.enabled = false;
                        jumpMultiForm.enabled = false;
                        shootingMultiForm.enabled = false;
                        defaultExplosiveForm.enabled = false;
                        jumpExplosiveForm.enabled = false;
                        shootingExplosiveForm.enabled = false;
                    } else if (PowUp.powerUps[3])
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
                        jumpExplosiveForm.enabled = true;
                        shootingExplosiveForm.enabled = false;
                    } else
                    {
                        defaultForm.enabled = false;
                        jumpForm.enabled = true;
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

    void GameOver()
    {
        isDead = true;
        gos.gameObject.SetActive(true);
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
                    defaultForm.enabled = false;
                    jumpForm.enabled = false;
                    shootingForm.enabled = false;
                    defaultJumpForm.enabled = true;
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
                    jumpCounter = 0;
                }
                else if (PowUp.powerUps[1])
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
                    defaultMultiForm.enabled = true;
                    jumpMultiForm.enabled = false;
                    shootingMultiForm.enabled = false;
                    defaultExplosiveForm.enabled = false;
                    jumpExplosiveForm.enabled = false;
                    shootingExplosiveForm.enabled = false;
                    jumpCounter = 0;
                }
                else if (PowUp.powerUps[2])
                {
                    defaultForm.enabled = false;
                    jumpForm.enabled = false;
                    shootingForm.enabled = false;
                    defaultJumpForm.enabled = false;
                    jumpJumpForm.enabled = false;
                    shootingJumpForm.enabled = false;
                    defaultSpeedForm.enabled = true;
                    jumpSpeedForm.enabled = false;
                    shootingSpeedForm.enabled = false;
                    defaultMultiForm.enabled = false;
                    jumpMultiForm.enabled = false;
                    shootingMultiForm.enabled = false;
                    defaultExplosiveForm.enabled = false;
                    jumpExplosiveForm.enabled = false;
                    shootingExplosiveForm.enabled = false;
                    jumpCounter = 0;
                }
                else if (PowUp.powerUps[3])
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
                    defaultExplosiveForm.enabled = true;
                    jumpExplosiveForm.enabled = false;
                    shootingExplosiveForm.enabled = false;
                    jumpCounter = 0;
                }
                else
                {
                    defaultForm.enabled = true;
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
                    jumpCounter = 0;
                }
            }
        }

        // Power Up
        if (collision.gameObject.CompareTag("Power Up"))
        {
            LosePowerUp();
            PowUp.RandomPowerup();
            Debug.Log(PowUp.powerUps[0]);
            Debug.Log(PowUp.powerUps[1]);
            Debug.Log(PowUp.powerUps[2]);
            Debug.Log(PowUp.powerUps[3]);
            Destroy(collision.gameObject);
        }

        // Next LvL
        if (collision.gameObject.CompareTag("Finish"))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
    }
    void LosePowerUp()
    {
        PowUp.powerUps[0] = false;
        PowUp.powerUps[1] = false;
        PowUp.powerUps[2] = false;
        PowUp.powerUps[3] = false;

        defaultForm.enabled = true;

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
