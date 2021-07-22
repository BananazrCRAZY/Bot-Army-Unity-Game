using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullet : MonoBehaviour
{
    public float speed = 12;
    public Score scoreCon;
    bool hasExploded = false;
    public SphereCollider explosionCollider;
    public ParticleSystem explosionParticles;
    public MeshRenderer explodeMesh;
    // Start is called before the first frame update
    void Start()
    {
        scoreCon = GameObject.FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasExploded == false)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        Destroy(gameObject, 5.0f);
    }

    void Explode()
    {
        explosionParticles.Play();
        explosionCollider.enabled = true;
        hasExploded = true;
        explodeMesh.enabled = true;
        Destroy(gameObject, 0.5f);
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
    }
}
