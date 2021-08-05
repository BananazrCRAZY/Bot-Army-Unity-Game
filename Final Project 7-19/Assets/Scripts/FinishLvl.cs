using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLvl : MonoBehaviour
{
    public GameObject player;
    public Transform nextLvl;
    public TimePassed tp;
    public float timeForLvl = 100f;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
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
            gm.timeStart = timeForLvl;
            tp.countdownStartTime = timeForLvl;
            tp.reset = true;
        }
    }
}
