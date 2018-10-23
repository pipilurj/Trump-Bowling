using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pincontrol : MonoBehaviour
{
    private float yRotation;
    private bool ifAlive;
    private pointercounter counterscript;
    private AudioSource yellAudio;
    // Use this for initialization
    void Start()
    {
        ifAlive = true;
        yRotation = transform.eulerAngles.y;
        counterscript = GameObject.FindWithTag("counter").GetComponent<pointercounter>();
        yellAudio = GameObject.FindWithTag("trumpYell").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(yRotation > 45 && ifAlive == true)
        {
            yellAudio.Play();
            counterscript.increaseCount();
            ifAlive = false;
        }
        else
        {
            yRotation = transform.eulerAngles.y;
        }
    }
}

