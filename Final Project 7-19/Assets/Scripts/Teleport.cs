using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject player;
    public Transform nextLvl;
    public BoxCollider col;
    bool disPor = false;
    float disPorTimer = 1f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.Equals(player))
        {
            player.transform.position = nextLvl.transform.position;
            disPor = true;
        }

        if (disPor)
        {
            col.enabled = false;
            disPorTimer -= Time.deltaTime;
            float invinCountdown = Mathf.Floor(disPorTimer);
            if (disPorTimer <= 0)
            {
                disPor = false;
            }
        }
    }
}
