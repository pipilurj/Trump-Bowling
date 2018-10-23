using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class gamecontrol : MonoBehaviour {
    private GameObject player;
    private Text result;
    private pointercounter counterScript;
    private timercontrol timer;
    private AudioSource loseAudio;
    private AudioSource winAudio;
    float yPosition;
    private bool ifEnded;
    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("player");
        result = GameObject.FindWithTag("result").GetComponent<Text>();
        counterScript = GameObject.FindWithTag("counter").GetComponent<pointercounter>();
        timer = GameObject.FindWithTag("timerobj").GetComponent<timercontrol>();
        loseAudio = GameObject.FindWithTag("loseaudio").GetComponent<AudioSource>();
        winAudio = GameObject.FindWithTag("winaudio").GetComponent<AudioSource>();
        result.text = "";
        ifEnded = false;
    }
	
	// Update is called once per frame
	void Update () {
        yPosition = player.transform.position.y;
        if (!ifEnded)
        {
            if (timer.getTime() >= 0 && counterScript.getCount() == 6)
            {
                win();
                ifEnded = true;
                winAudio.Play();
            }
            else if ((timer.getTime() < 0 && counterScript.getCount() < 6)||yPosition < 2)
            {
                lose();
                ifEnded = true;
                loseAudio.Play();
            }
        }
        if (Input.GetKey(KeyCode.R))
        {
            RestartGame();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            QuitGame();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (Time.timeScale != 0.5f)
            {
                Time.timeScale = 0.5f;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale != 0.0f)
            {
                Time.timeScale = 0.0f;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("booling");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("running");
        }
    }
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void QuitGame()
    {
        Application.Quit();
    }
    public void lose()
    {
        result.text = "You have failed to defeat Trump!\nPress R to restart and Q to quit...";
    }
    public void win()
    {
        result.text = "You have defeated Trump!\nPress R to restart and Q to quit...";
    }
}
