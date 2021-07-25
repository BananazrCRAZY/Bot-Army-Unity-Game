using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePassed : MonoBehaviour
{
    public float spawnTimer = 0f;
    public float countDownTimer;

    public float countdownStartTime = 100f;

    //public Text timerText;
    public Text countDownText;
    public PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        countDownTimer = countdownStartTime;
    }

    // Update is called once per frame
    void Update()
    {
        pc = GameObject.FindObjectOfType<PlayerController>();
        if (pc.isDead)
        {
            return;
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
