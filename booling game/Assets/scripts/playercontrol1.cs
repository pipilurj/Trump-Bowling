using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol1 : MonoBehaviour {
    private playermovement movement;
    private playerstatus status;
    private bool ifRecordedNode;
    private float targetX;
    private float targetZ;
    // Use this for initialization
    void Awake () {
        status = new playerstatus(this.gameObject);
        movement = new playermovement(status, this.gameObject);
        status.setdirectionChar('f');
        status.setTurnDirectionChar('f');
        status.setspeed(0);
        status.setdirectionVector(Vector3.forward);
        status.setVelocity(status.getdirectionVector() * status.getspeed());
        status.setIfLocked(false);
        status.setIfTurning(false);
        ifRecordedNode = false;
        targetX = 10;
        targetZ = 190;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z == targetZ && transform.position.x == targetX)
        {
            status.setresult("win");
        }
        if (!movement.hasChildInFront(status.getdirectionChar())&&movement.pastMidPoint()&&!status.getIfTurning())
        {
            status.setspeed(0);
            status.setVelocity(Vector3.zero);
            status.setdirectionVector(Vector3.zero);
            transform.position = movement.midPoint(true);
            status.setIfLocked(true);
        }
        if (status.getIflocked()){
            movement.chooseDir();
            if(ifRecordedNode == true)
            {
                ifRecordedNode = false;
            }
        }
        else
        {
            movement.transformController();
            if (!status.getIfTurning()&&movement.hasChildInFront(status.getdirectionChar()))
            {
                if (movement.pastMidPoint() && !ifRecordedNode)
                {
                    ifRecordedNode = true;
                    movement.enqueuePath(new pathnode(status.getdirectionChar()));
                }
            }
            if (!movement.pastMidPoint())
            {
                ifRecordedNode = false;
            }
        }
    }
    public playerstatus getplayerstatus()
    {
        return this.status;
    }
    public playermovement getplayermovement()
    {
        return this.movement;
    }
    private void OnTriggerEnter(Collider chaserCollider)
    {
        if(chaserCollider.gameObject.tag == "chaser")
        {
            this.status.setspeed(0);
            this.status.setAccelaration(0);
            this.status.setresult("lose");
        }

    }
}
