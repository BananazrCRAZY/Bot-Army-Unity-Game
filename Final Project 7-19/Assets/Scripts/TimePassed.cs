using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePassed : MonoBehaviour
{
    float spawnTimer = 0f;
    float countDownTimer;

    public float countdownStartTime = 100f;

    public TextAlignment timerText;
    public TextAlignment countDownText;
    public PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        countDownTimer = countdownStartTime;
    }

    // Update is called once per frame
    void Update()
    {
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
            //countDownText.text = 0.ToString();
        }
        else
        {
            //countDownText.text = flooredCountDownTimer.ToString;
        }
    }
}
