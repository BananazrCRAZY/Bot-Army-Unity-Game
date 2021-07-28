using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public PlayerController pc;
    public GameObject player;
    public BoxCollider portalCol;
    public bool newSpawn = false;
    private void Awake()
    {
        /*if (GameObject.FindObjectsOfType<SpawnPoint>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }*/
    }
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        pc = GameObject.FindObjectOfType<PlayerController>();

        /*if (Input.GetKey(KeyCode.F))
        {
            transform.position = pc.transform.position;
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.Equals(player))
        {
            portalCol.enabled = false;
            newSpawn = true;
        }
    }
}
