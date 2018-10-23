using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathnode {
    private char direction;
    public pathnode(char direction)
    {
        this.direction = direction;
    }
    public char getDir()
    {
        return this.direction;
    }
}
