using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLvl : MonoBehaviour
{
    public GameObject player;
    public Transform nextLvl;
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
        }
    }
}
