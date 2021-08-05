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
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.FindObjectOfType<PlayerController>();
        gm = GameObject.FindObjectOfType<GameManager>();

        countdownStartTime = gm.timeStart;
        countDownTimer = countdownStartTime;
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
            pc.GameOver();
        }
        else
        {
            countDownText.text = "Time: " + flooredCountDownTimer.ToString();
        }
    }
}
