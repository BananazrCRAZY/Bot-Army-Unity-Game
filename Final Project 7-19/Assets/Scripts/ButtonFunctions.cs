using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public Score scoreCon;
    public TimePassed timeCon;
    //public GameObject player;
    //public SpawnPoint sp;
    public bool reload = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreCon = GameObject.FindObjectOfType<Score>();
        timeCon = GameObject.FindObjectOfType<TimePassed>();
        //sp = GameObject.FindObjectOfType<SpawnPoint>();
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

        //player.transform.position = new Vector3(sp.spawn.x, sp.spawn.y, sp.spawn.z);
        reload = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
