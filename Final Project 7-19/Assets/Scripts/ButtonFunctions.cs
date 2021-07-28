using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public Score scoreCon;
    public TimePassed timeCon;
    public SpawnPoint sp;
    public bool reload = false;
    public Vector3 spawn;

    // Start is called before the first frame update
    void Start()
    {
        scoreCon = GameObject.FindObjectOfType<Score>();
        timeCon = GameObject.FindObjectOfType<TimePassed>();
        sp = GameObject.FindObjectOfType<SpawnPoint>();
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

        reload = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
