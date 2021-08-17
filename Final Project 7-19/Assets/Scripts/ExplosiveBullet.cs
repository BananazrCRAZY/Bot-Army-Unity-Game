using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullet : MonoBehaviour
{
    public int speed = 50;
    public Score scoreCon;
    bool hasExploded = false;
    public SphereCollider explosionCollider;
    public ParticleSystem explosionParticles;
    public MeshRenderer explodeMesh;
    public Boss boss;
    // Start is called before the first frame update
    void Start()
    {
        scoreCon = GameObject.FindObjectOfType<Score>();
        boss = GameObject.FindObjectOfType<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasExploded == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        Destroy(gameObject, 5.0f);
    }

    void Explode()
    {
        explosionParticles.Play();
        explosionCollider.enabled = true;
        hasExploded = true;
        explodeMesh.enabled = true;
        Destroy(gameObject, 2f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (hasExploded == false)
            {
                Explode();
            }
            other.gameObject.SetActive(false);
            scoreCon.score++;
        }
        if (other.gameObject.CompareTag("Platform"))
        {
            gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            boss.bossHealth--;
            gameObject.SetActive(false);
        }
    }
}
