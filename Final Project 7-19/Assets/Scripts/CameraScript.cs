using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public float addHeight = 2.1f;
    public PlayerController pc;
    Vector3 f;
    public float orthoSize = 6;
    public float newOrtho = 25;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindObjectOfType<PlayerController>();
        Camera.main.orthographicSize = orthoSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.canZoom)
        {
            Camera.main.orthographicSize = newOrtho;
            pc.canZoom = false;
        } else
        {
            f = new Vector3(player.transform.position.x, player.transform.position.y + addHeight, this.transform.position.z);
        }

        this.transform.position = f;
    }
}
