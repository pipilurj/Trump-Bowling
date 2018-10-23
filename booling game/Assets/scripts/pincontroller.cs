using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pincontroller : MonoBehaviour {

    // Use this for initialization
    private float magnitude;
    private float frequency;
    private float offset;
    void Start () {
        magnitude = Random.Range(0, 5.0f);
        frequency = Random.Range(4, 5);
        offset = Random.Range(0, 3.14f);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = transform.position;
        newPos.y = JumpHeight(Time.time);
        transform.position = newPos;
    }
    private float JumpHeight(float time)
    {
        float height = Mathf.Abs(magnitude * Mathf.Sin(frequency * time + offset))+4.0f;
        return height;
    }
}
