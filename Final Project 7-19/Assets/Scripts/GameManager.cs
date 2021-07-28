using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static bool created = false;

    [SerializeField]
    private Vector3 checkPoint;

    public Vector3 spawn;

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
    }

    public void equ()
    {
        spawn = checkPoint;
    }
}
