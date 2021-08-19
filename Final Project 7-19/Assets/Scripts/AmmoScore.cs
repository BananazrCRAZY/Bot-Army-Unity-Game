using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoScore : MonoBehaviour
{
    public PlayerController pc;
    public Text ammoText;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = "Ammo: " + pc.Ammo;

    }
}
