using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public Score scoreCon;
    public TimePassed timeCon;
    public SpawnPoint sp;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        scoreCon = GameObject.FindObjectOfType<Score>();
        timeCon = GameObject.FindObjectOfType<TimePassed>();
        sp = GameObject.FindObjectOfType<SpawnPoint>();
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartScene()
    {
        scoreCon.score = 0;
        timeCon.spawnTimer = 0;
        timeCon.countDownTimer = timeCon.countdownStartTime;

        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
