using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasermovement{
    private chaserstatus status;
    private GameObject chaser;
    private Queue<pathnode> pathqueue;
    private string[] platform = GameObject.FindWithTag("platform").GetComponent<MapGenerator>().getPlatform();
    public chasermovement(chaserstatus status, GameObject chaser, Queue<pathnode> pathqueue)
    {
        this.status = status;
        this.chaser = chaser;
        this.pathqueue = pathqueue;
    }
    public void transformController()
    {

        if (status.getspeed() < 30)
        {
            status.setspeed(status.getspeed() + status.getAccelaration() * Time.deltaTime);
            if (status.getspeed() > 30)
            {
                status.setspeed(30);
            }
        }
        this.status.setVelocity(status.getdirectionVector() * Time.deltaTime * status.speed);
        chaser.transform.Translate(status.getVelocity(), Space.World);
    }

    public bool hasTileAt(int x, int z)
    {
        if (platform[z][x] == '*')
        {
            return true;
        }
        return false;
    }
    public bool pastMidPoint()
    {
        if (status.getdirectionChar() == 'f')
        {
            if (chaser.transform.position.z % 10 < 5 && chaser.transform.position.z % 10 > 0)
            {
                return true;
            }
        }
        else if (status.getdirectionChar() == 'b')
        {
            if (chaser.transform.position.z % 10 > 5 || chaser.transform.position.z < 0)
            {
                return true;
            }
        }
        else if (status.getdirectionChar() == 'l')
        {
            if (chaser.transform.position.x % 10 > 5 || chaser.transform.position.x < 0)
            {
                return true;
            }
        }
        else if (status.getdirectionChar() == 'r')
        {
            if (chaser.transform.position.x % 10 < 5 && chaser.transform.position.x % 10 > 0)
            {
                return true;
            }
        }
        return false;
    }
    public Vector3 midPoint(bool ifPast)
    {
        if (ifPast)
        {
            if (status.getdirectionChar() == 'f')
            {
                return new Vector3(chaser.transform.position.x, chaser.transform.position.y, chaser.transform.position.z - chaser.transform.position.z % 5);
            }
            else if (status.getdirectionChar() == 'b')
            {
                if (chaser.transform.position.z > 0)
                    return new Vector3(chaser.transform.position.x, chaser.transform.position.y, chaser.transform.position.z - chaser.transform.position.z % 5 + 5);
                return new Vector3(chaser.transform.position.x, chaser.transform.position.y, 0);
            }
            else if (status.getdirectionChar() == 'l')
            {
                if (chaser.transform.position.x > 0)
                    return new Vector3(chaser.transform.position.x - chaser.transform.position.x % 5 + 5, chaser.transform.position.y, chaser.transform.position.z);
                return new Vector3(0, chaser.transform.position.y, chaser.transform.position.z);
            }
            else
            {
                return new Vector3(chaser.transform.position.x - chaser.transform.position.x % 5, chaser.transform.position.y, chaser.transform.position.z);
            }
        }
        else
        {
            if (status.getdirectionChar() == 'f')
            {
                return new Vector3(chaser.transform.position.x, chaser.transform.position.y, chaser.transform.position.z - chaser.transform.position.z % 5 + 5);
            }
            else if (status.getdirectionChar() == 'b')
            {
                if (chaser.transform.position.z > 0)
                    return new Vector3(chaser.transform.position.x, chaser.transform.position.y, chaser.transform.position.z - chaser.transform.position.z % 5);
                return new Vector3(chaser.transform.position.x, chaser.transform.position.y, 0);
            }
            else if (status.getdirectionChar() == 'l')
            {
                if (chaser.transform.position.x > 0)
                    return new Vector3(chaser.transform.position.x - chaser.transform.position.x % 5, chaser.transform.position.y, chaser.transform.position.z);
                return new Vector3(0, chaser.transform.position.y, chaser.transform.position.z);
            }
            else
            {
                return new Vector3(chaser.transform.position.x - chaser.transform.position.x % 5 + 5, chaser.transform.position.y, chaser.transform.position.z);
            }
        }
    }
    public void directionManager(char turningDir)
    {
        if(turningDir!= status.getdirectionChar())
        {
            if(turningDir == 'f')
            {
                status.setdirectionChar('f');
                status.setdirectionVector(Vector3.forward);
            }
            else if (turningDir == 'r')
            {
                status.setdirectionChar('r');
                status.setdirectionVector(Vector3.right);
            }
            else if (turningDir == 'b')
            {
                status.setdirectionChar('b');
                status.setdirectionVector(Vector3.back);
            }
            else if (turningDir == 'l')
            {
                status.setdirectionChar('l');
                status.setdirectionVector(Vector3.left);
            }
        }
    }
}
