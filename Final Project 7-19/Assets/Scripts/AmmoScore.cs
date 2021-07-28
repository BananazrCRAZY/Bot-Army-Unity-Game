using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoScore : MonoBehaviour
{
    public ShooterCode shootC;
    public Text ammoText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = "Ammo: " + shootC.Ammo;

    }
}
