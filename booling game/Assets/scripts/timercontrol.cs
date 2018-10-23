using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timercontrol : MonoBehaviour {

    // Use this for initialization
    float timeLeft;
    Text timerText;

   
    void Start () {
        timerText = GameObject.FindWithTag("timer").GetComponent <Text>();

        timeLeft = 10.0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (timeLeft >0)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = "You have " + timeLeft.ToString("0.##") +" s";
        }
    }
    public float getTime()
    {
        return timeLeft;
    }
}
