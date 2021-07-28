using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public PlayerController pc;
    public GameObject player;
    public BoxCollider portalCol;
    public Vector3 spawn;
    public ButtonFunctions bf;

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

        if (bf.reload)
        {
            player.transform.position = spawn;
            bf.reload = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.Equals(player))
        {
            spawn = transform.position;
            portalCol.enabled = false;
        }
    }
}
