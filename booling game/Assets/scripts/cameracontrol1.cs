using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrol1 : MonoBehaviour {
    public GameObject player;
    private playerstatus status;
    private Vector3 offset;
    private char currentCameraAngleChar;
    private float anglespeed = 2;
    private float currentCameraAngle;
    // Use this for initialization
    void Start () {
        status = player.GetComponent<playercontrol1>().getplayerstatus();
        transform.LookAt(player.transform);
        offset = transform.position - player.transform.position;
        currentCameraAngleChar = 'f';
        currentCameraAngle = 0;
    }
	
	// Update is called once per frame
	void LateUpdate() {
        transform.LookAt(player.transform);
        status = player.GetComponent<playercontrol1>().getplayerstatus();
        if(currentCameraAngle != this.dirchartoint(status.getdirectionChar()))
        {
            currentCameraAngle = Mathf.LerpAngle(currentCameraAngle, this.dirchartoint(status.getdirectionChar()), anglespeed * Time.deltaTime);
            offset = new Vector3(-20*Mathf.Sin(currentCameraAngle* Mathf.Deg2Rad), 30, -20*Mathf.Cos(currentCameraAngle*Mathf.Deg2Rad));

        }
        transform.position = player.transform.position + offset;

    }

    public void setOffset(Vector3 newOffSet)
    {
        offset = newOffSet;
    }
    public Vector3 getOffset()
    {
        return offset;
    }
    public float dirchartoint(char dir)
    {
        if(dir == 'f')
        {
            return 0;
        }else if(dir == 'r')
        {
            return 90;
        }else if(dir == 'b')
        {
            return 180;
        }
        else
        {
            return 270;
        }
    }
}
