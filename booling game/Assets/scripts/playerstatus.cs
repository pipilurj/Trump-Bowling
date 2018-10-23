using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerstatus{
    private GameObject player;
    public float speed;
    private float acceleration = 10;
    private Vector3 velocity;
    private Vector3 directionVector;
    private char directionChar;
    private char turnDirectionChar;
    private bool ifLocked;
    private bool ifTurning;
    private string result = "pending";
    public playerstatus(GameObject player)
    {
        this.player = player;
    }
    public float getAccelaration()
    {
        return this.acceleration;
    }
    public void setspeed(float speed)
    {
        this.speed = speed;
    }
    public float getspeed()
    {
        return this.speed;
    }
    public Vector3 getVelocity()
    {
        return velocity;
    }
    public void setVelocity(Vector3 velocity)
    {
        this.velocity = velocity;
    }
    public Vector3 getdirectionVector()
    {
        return this.directionVector;
    }
    public void setdirectionVector(Vector3 directionVector)
    {
        this.directionVector = directionVector;
    }
    public char getdirectionChar()
    {
        return this.directionChar;
    }
    public void setdirectionChar(char directionchar)
    {
        this.directionChar = directionchar;
    }
    public char getTurnDirectionChar()
    {
        return this.turnDirectionChar;
    }
    public void setTurnDirectionChar(char turndirectionChar)
    {
        this.turnDirectionChar = turndirectionChar;
    }
    public bool getIflocked()
    {
        return this.ifLocked;
    }
    public bool getIfTurning()
    {
        return this.ifTurning;
    }
    public void setIfLocked(bool ifLocked)
    {
        this.ifLocked = ifLocked;
    }
    public void setIfTurning(bool ifTurning)
    {
        this.ifTurning = ifTurning;
    }
    public void setAccelaration(float accelatation)
    {
        this.acceleration = accelatation;
    }
    public void setresult(string result)
    {
        this.result  = result;
    }
    public string getresult()
    {
        return this.result;
    }
}
