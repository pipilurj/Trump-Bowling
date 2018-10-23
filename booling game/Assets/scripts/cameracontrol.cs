using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrol : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private bool stable;

    // Use this for initialization
    void Start()
    {
        stable = false;
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.z < 50 && !stable)
        {
            transform.position = player.transform.position + offset;
        }
        else if(!stable)
        {
            stable = true;
        }
    }
}