using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamecontrol2 : MonoBehaviour {
    public GameObject player;
    private playerstatus playerstatus;
    private Text result;
    private AudioSource loseAudio;
    private AudioSource winAudio;
    private bool end;
    // Use this for initialization
    void Start () {
        result = GameObject.FindWithTag("result2").GetComponent<Text>();
        playerstatus = player.GetComponent<playercontrol1>().getplayerstatus();
        result.text = "";
        winAudio = GameObject.FindWithTag("winaudio2").GetComponent<AudioSource>();
        loseAudio = GameObject.FindWithTag("loseaudio2").GetComponent<AudioSource>();
        end = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!end)
        {
            if (playerstatus.getresult() == "win")
            {
                win();
            }
            else if (playerstatus.getresult() == "lose")
            {
                lose();
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            QuitGame();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(Time.timeScale != 0.5f)
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
            if(Time.timeScale !=0.0f)
            {
                Time.timeScale = 0.0f;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
        }
    }

    public void lose()
    {
        loseAudio.Play();
        end = true;
        result.text = "You are beaten by Trump horde!!\nPress R to restart and Q to quit...";
  
    }
    public void win()
    {
        winAudio.Play();
        end = true;
        result.text = "Trump is too slow to catch you!!!!\nPress R to restart and Q to quit...";
    }
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private void QuitGame()
    {
        Application.Quit();
    }
}
