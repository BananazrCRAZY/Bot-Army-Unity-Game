using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Start pos for player is x:-5 y:-0.65 z:0
    //Comment out line 57 to test things

    public int speed = 8;
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
    public MeshRenderer godForm;

    public GameoverScreen gos;
    public ButtonFunctions bf;
    public GameManager gm;

    public bool facingRight = true;

    public bool god = false;
    public int godLives = 5;
    public Text lifeText;
    public GameObject godLifeUI;
    public Text bossHealth;
    public GameObject bossHeartUI;

    public bool canZoom = false;

    // Shooting vars
    public GameObject Bullet;
    public GameObject explosiveBullet;
    public GameObject godBullet;
    public bool canShoot = true;
    public float timeBetweenShot = 0.5f;
    private float timeUntilNextShot;
    public int Ammo = 5;
    Vector3 currentPos;
    Vector3 newPos;

    float holdShooingForm = 0.1f;
    public float timeShootingForm;
    public bool canSwitchForm = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gos = GameObject.FindObjectOfType<GameoverScreen>();
        bf = GameObject.FindObjectOfType<ButtonFunctions>();
        gm = GameObject.FindObjectOfType<GameManager>();
        // Comment out the line below to test things
        transform.position = gm.spawn;
        LosePowerUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (PowUp.powerUps[0])
        {
            jumpForce = 8f;

            speed = 8;
            jumpCheats = false;
            timeBetweenShot = 0.5f;
        }
        else if (PowUp.powerUps[1])
        {
            timeBetweenShot = 0.4f;

            speed = 8;
            jumpForce = 5.2f;
            jumpCheats = false;
        }
        else if (PowUp.powerUps[2])
        {
            speed = 15;
            timeBetweenShot = 0.3f;

            jumpForce = 5.2f;
            jumpCheats = false;
        } 
        else if (PowUp.powerUps[3])
        {
            timeBetweenShot = 0.34f;

            speed = 8;
            jumpForce = 5.2f;
            jumpCheats = false;
        } 
        else if (god)
        {
            speed = 30;
            jumpForce = 9f;
            jumpCheats = true;
            timeBetweenShot = 0.2f;
            lifeText.text = " " + godLives + " ";
        }
        else
        {
            ResetStats();
        }

        if (transform.position.y <= -91)
        {
            GameOver();
        }

        if (isDead == false)
        {
            if (Input.GetKey(KeyCode.D))
            {
                facingRight = true;
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z);
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                facingRight = false;
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
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
                    } else if (god)
                    {
                        NoMesh();
                        godForm.enabled = true;
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

        // Shooting code
        if (Time.time > timeUntilNextShot)
        {
            canShoot = true;
        }

        currentPos = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        if (isDead == false && Input.GetMouseButton(0) && canShoot && (Ammo > 0 || god))
        {
            if (PowUp.powerUps[1])
            {
                canShoot = false;
                timeUntilNextShot = Time.time + timeBetweenShot;

                NoMesh();
                shootingMultiForm.enabled = true;

                newPos = new Vector3(transform.position.x, currentPos.y + 0.5f, transform.position.z);
                Instantiate(Bullet, newPos, this.transform.rotation);
                newPos = new Vector3(transform.position.x, currentPos.y - 0.5f, transform.position.z);
                Instantiate(Bullet, newPos, this.transform.rotation);
                newPos = new Vector3(transform.position.x, currentPos.y - 1f, transform.position.z);
                Instantiate(Bullet, newPos, this.transform.rotation);
                newPos = new Vector3(transform.position.x, currentPos.y + 1f, transform.position.z);
                Instantiate(Bullet, newPos, this.transform.rotation);
                CreateBullet();
                bool canSwitchForm = false;
                if (Ammo == 1)
                {
                    Ammo--;
                }
                else
                {
                    Ammo -= 2;
                }
            }
            else if (PowUp.powerUps[2])
            {
                canShoot = false;
                timeUntilNextShot = Time.time + timeBetweenShot;

                NoMesh();
                shootingSpeedForm.enabled = true;

                CreateBullet();
                Ammo--;
            }
            else if (PowUp.powerUps[3])
            {
                canShoot = false;
                timeUntilNextShot = Time.time + timeBetweenShot;

                NoMesh();
                shootingExplosiveForm.enabled = true;

                Instantiate(explosiveBullet, currentPos, this.transform.rotation);
                bool canSwitchForm = false;
                if (Ammo == 1)
                {
                    Ammo--;
                }
                else
                {
                    Ammo -= 2;
                }
            }
            else if (PowUp.powerUps[0])
            {
                canShoot = false;
                timeUntilNextShot = Time.time + timeBetweenShot;

                NoMesh();
                shootingJumpForm.enabled = true;

                CreateBullet();
                Ammo--;
            }
            else if (god)
            {
                canShoot = false;
                timeUntilNextShot = Time.time + timeBetweenShot;

                NoMesh();
                godForm.enabled = true;

                newPos = new Vector3(transform.position.x, currentPos.y - 2.5f, transform.position.z);
                Instantiate(godBullet, newPos, this.transform.rotation);
                bool canSwitchForm = false;
            }
            else
            {
                canShoot = false;
                timeUntilNextShot = Time.time + timeBetweenShot;

                NoMesh();
                shootingForm.enabled = true;

                CreateBullet();
                Ammo--;
            }
        }

        if (Time.time > timeShootingForm)
        {
            bool canSwitchForm = true;
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
            damaged();
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            damaged();
        }
    }

    // jump fix
    private void OnCollisionEnter(Collision collision)
    {
        // Double Jump
        if (collision.gameObject.CompareTag("Platform"))
        {
            if (canSwitchForm)
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
                else if (god)
                {
                    NoMesh();
                    godForm.enabled = true;
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
            if (!god)
            {
                LosePowerUp();
                PowUp.RandomPowerup();
                Destroy(collision.gameObject);
            }
        }

        // Next LvL
        /*if (collision.gameObject.CompareTag("Finish"))
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }*/

        if (collision.gameObject.CompareTag("Ammo"))
        {
            Ammo += 5;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Virus"))
        {
            Application.Quit();
        }
        
        if (collision.gameObject.CompareTag("Godpowerup"))
        {
            LosePowerUp();
            NoMesh();
            god = true;
            godLives = 5;
            godForm.enabled = true;
            GodUI(true);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("BossLVL"))
        {
            BossUI(true);
            canZoom = true;
        }
    }
    void LosePowerUp()
    {
        PowUp.powerUps[0] = false;
        PowUp.powerUps[1] = false;
        PowUp.powerUps[2] = false;
        PowUp.powerUps[3] = false;
        god = false;
        GodUI(false);

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
        godForm.enabled = false;
    }

    public void ResetStats()
    {
        speed = 8;
        jumpForce = 5.2f;
        jumpCheats = false;
        timeBetweenShot = 0.5f;
        GodUI(false);
    }

    public void GodUI(bool tf)
    {
        lifeText.gameObject.SetActive(tf);
        godLifeUI.gameObject.SetActive(tf);
    }
    public void BossUI(bool tf)
    {
        bossHealth.gameObject.SetActive(tf);
        bossHeartUI.gameObject.SetActive(tf);
    }

    public void damaged()
    {
        if (!invicible)
        {
            if (PowUp.powerUps[0] == true || PowUp.powerUps[1] == true || PowUp.powerUps[2] == true || PowUp.powerUps[3] == true)
            {
                LosePowerUp();
                invicible = true;
            }
            else if (god)
            {
                godLives--;
                invicible = true;
                if (godLives <= 0)
                {
                    LosePowerUp();
                    godLives = 3;
                    jumpCounter = 0;
                }
            }
            else
            {
                GameOver();
            }
        }
    }

    public void CreateBullet()
    {
        Instantiate(Bullet, currentPos, this.transform.rotation);
        bool canSwitchForm = false;
    }
}