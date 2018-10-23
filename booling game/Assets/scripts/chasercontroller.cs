using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasercontroller : MonoBehaviour {

    // Use this for initialization
    public GameObject player;
    private playermovement playermovement;
    private Queue<pathnode> movequeue;
    private bool ifDequeued;
    private chaserstatus status;
    private chasermovement chasermovement;

    void Start () {
        this.status = new chaserstatus();
        this.playermovement = player.GetComponent<playercontrol1>().getplayermovement();
        this.movequeue = this.playermovement.getQueue();
        this.status.setdirectionChar('f');
        this.status.setspeed(0);
        this.status.setdirectionVector(Vector3.forward);
        this.status.setVelocity(status.getdirectionVector() * status.getspeed());
        this.chasermovement = new chasermovement(this.status, this.gameObject, this.movequeue);
        ifDequeued = false;
    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player.transform);
        if (!chasermovement.pastMidPoint() && ifDequeued)
        {
            ifDequeued = false;
        }
        if (chasermovement.pastMidPoint() && !ifDequeued&&movequeue.Count!=0)
        {
            ifDequeued = true;
            if (movequeue.Peek().getDir() != status.getdirectionChar())
            {
                transform.position = chasermovement.midPoint(true);
            }
            chasermovement.directionManager(movequeue.Peek().getDir());
            movequeue.Dequeue();
        }
        chasermovement.transformController();

    }
    private void OnTriggerEnter(Collider playerCollider)
    {
        if (playerCollider.gameObject.tag == "player")
        {
            this.status.setspeed(0);
            this.status.setAccelaration(0);
        }
    }

}
