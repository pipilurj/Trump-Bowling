using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaserstatus{
    public float speed;
    private float acceleration = 5;
    private Vector3 velocity;
    private Vector3 directionVector;
    private char directionChar;
    public chaserstatus()
    {

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
    public void setAccelaration(float accelatation)
    {
        this.acceleration = accelatation;
    }
}
