using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePassed : MonoBehaviour
{
    public float spawnTimer = 0f;
    public float countDownTimer;
    public bool reset = false;

    public float countdownStartTime = 100f;

    //public Text timerText;
    public Text countDownText;
    public PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        countDownTimer = countdownStartTime;
        pc = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pc.isDead)
        {
            return;
        }

        if (reset)
        {
            countDownTimer = countdownStartTime;
            reset = false;
        }

        spawnTimer += Time.deltaTime;
        float roundedSpawnTimer = Mathf.Round(spawnTimer * 10) / 10;
       // timerText.text = "Time: " + roundedSpawnTimer;
        countDownTimer -= Time.deltaTime;
        float flooredCountDownTimer = Mathf.Floor(countDownTimer) + 1;
        if(countDownTimer <= 0)
        {
            countDownText.text = "Time: " + 0.ToString();
        }
        else
        {
            countDownText.text = "Time: " + flooredCountDownTimer.ToString();
        }
    }
}
