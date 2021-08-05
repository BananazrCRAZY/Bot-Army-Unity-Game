using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static bool created = false;

    [SerializeField]
    private Vector3 checkPoint;

    public Vector3 spawn;

    [SerializeField]
    private float time = 100f;

    public float timeStart = 100f;

    private void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
            equ();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkPoint = spawn;
        time = timeStart;
    }

    public void equ()
    {
        timeStart = time;
        spawn = checkPoint;
    }
}
