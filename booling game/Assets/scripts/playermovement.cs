using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement {
    private playerstatus status;
    private GameObject player;
    private Queue<pathnode> pathqueue;
    private string[] platform = GameObject.FindWithTag("platform").GetComponent<MapGenerator>().getPlatform();
    private AudioSource friction = GameObject.FindWithTag("friction").GetComponent<AudioSource>();
    private AudioSource turn = GameObject.FindWithTag("turn").GetComponent<AudioSource>();
    public playermovement(playerstatus status, GameObject player)
    {
        this.status = status;
        this.player = player;
        pathqueue = new Queue<pathnode>();
    }
    public void transformController()
    {

        chooseDir();

        if (status.getspeed() < 30)
        {
            status.setspeed(status.getspeed() + status.getAccelaration() * Time.deltaTime);
            if (status.getspeed() > 30)
            {
                status.setspeed(30);
            }
        }
        this.status.setVelocity(status.getdirectionVector() * Time.deltaTime * status.speed);
        player.transform.Translate(status.getVelocity(), Space.World);
    }
    public bool hasChildInFront(char direction)
    {
        int[] tilePosition = { (int)(player.transform.position.x + 5) / 10, (int)(player.transform.position.z + 5) / 10 };
        if (direction == 'f')
        {
            if (tilePosition[1] >= platform.Length - 1)
            {
                return false;
            }
            else
            {
                return hasTileAt(tilePosition[0], tilePosition[1] + 1);
            }
        }
        else if (direction == 'b')
        {
            if (tilePosition[1] <= 0)
            {
                return false;
            }
            else
            {
                return hasTileAt(tilePosition[0], tilePosition[1] - 1);
            }
        }
        else if (direction == 'l')
        {
            if (tilePosition[0] <= 0)
            {
                return false;
            }
            else
            {
                return hasTileAt(tilePosition[0] - 1, tilePosition[1]);
            }
        }
        else if (direction == 'r')
        {
            if (tilePosition[0] >= platform[tilePosition[1]].Length - 1)
            {
                return false;
            }
            else
            {
                return hasTileAt(tilePosition[0] + 1, tilePosition[1]);
            }
        }
        return false;

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
            if (player.transform.position.z % 10 <= 5 && player.transform.position.z % 10 > 0)
            {
                return true;
            }
        }
        else if (status.getdirectionChar() == 'b')
        {
            if (player.transform.position.z % 10 >= 5 || player.transform.position.z < 0)
            {
                return true;
            }
        }
        else if (status.getdirectionChar() == 'l')
        {
            if (player.transform.position.x % 10 >= 5 || player.transform.position.x < 0)
            {
                return true;
            }
        }
        else if (status.getdirectionChar() == 'r')
        {
            if (player.transform.position.x % 10 <= 5 && player.transform.position.x % 10 > 0)
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
                return new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - player.transform.position.z % 5);
            }
            else if (status.getdirectionChar() == 'b')
            {
                if (player.transform.position.z > 0)
                    return new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - player.transform.position.z % 5 + 5);
                return new Vector3(player.transform.position.x, player.transform.position.y, 0);
            }
            else if (status.getdirectionChar() == 'l')
            {
                if (player.transform.position.x > 0)
                    return new Vector3(player.transform.position.x - player.transform.position.x % 5 + 5, player.transform.position.y, player.transform.position.z);
                return new Vector3(0, player.transform.position.y, player.transform.position.z);
            }
            else
            {
                return new Vector3(player.transform.position.x - player.transform.position.x % 5, player.transform.position.y, player.transform.position.z);
            }
        }
        else
        {
            if (status.getdirectionChar() == 'f')
            {
                return new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - player.transform.position.z % 5 + 5);
            }
            else if (status.getdirectionChar() == 'b')
            {
                if (player.transform.position.z > 0)
                    return new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - player.transform.position.z % 5);
                return new Vector3(player.transform.position.x, player.transform.position.y, 0);
            }
            else if (status.getdirectionChar() == 'l')
            {
                if (player.transform.position.x > 0)
                    return new Vector3(player.transform.position.x - player.transform.position.x % 5, player.transform.position.y, player.transform.position.z);
                return new Vector3(0, player.transform.position.y, player.transform.position.z);
            }
            else
            {
                return new Vector3(player.transform.position.x - player.transform.position.x % 5 + 5, player.transform.position.y, player.transform.position.z);
            }
        }
    }
    public bool hasChildOnSides(char turningDir)
    {
        int[] tilePosition = { (int)(player.transform.position.x + 5) / 10, (int)(player.transform.position.z + 5) / 10 };
        if (status.getdirectionChar() == 'f')
        {
            if (turningDir == 'l')
            {
                if (tilePosition[0] <= 0)
                    return false;
                else return hasTileAt(tilePosition[0] - 1, tilePosition[1]);
            }
            else
            {
                if (tilePosition[0] >= platform[tilePosition[1]].Length - 1)
                    return false;
                else return hasTileAt(tilePosition[0] + 1, tilePosition[1]);
            }
        }
        else if (status.getdirectionChar() == 'b')
        {
            if (turningDir == 'r')
            {
                if (tilePosition[0] <= 0)
                    return false;
                else return hasTileAt(tilePosition[0] - 1, tilePosition[1]);
            }
            else
            {
                if (tilePosition[0] >= platform[tilePosition[1]].Length - 1)
                    return false;
                else return hasTileAt(tilePosition[0] + 1, tilePosition[1]);
            }
        }
        else if (status.getdirectionChar() == 'l')
        {
            if (turningDir == 'l')
            {
                if (tilePosition[1] <= 0)
                    return false;
                else return hasTileAt(tilePosition[0], tilePosition[1] - 1);
            }
            else
            {
                if (tilePosition[1] >= platform.Length + 1)
                    return false;
                else return hasTileAt(tilePosition[0], tilePosition[1] + 1);
            }
        }
        else
        {
            if (turningDir == 'r')
            {
                if (tilePosition[1] <= 0)
                    return false;
                else return hasTileAt(tilePosition[0], tilePosition[1] - 1);
            }
            else
            {
                if (tilePosition[1] >= platform.Length + 1)
                    return false;
                else return hasTileAt(tilePosition[0], tilePosition[1] + 1);
            }
        }
    }
    public void chooseDir()
    {
        if (!status.getIfTurning())
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                
                if (!pastMidPoint() && hasChildOnSides('l'))
                {
                    turn.Play();
                    if (!status.getIflocked())
                    {
                        
                        status.setIfTurning(true);
                        if (status.getdirectionChar() == 'f')
                        {
                            status.setTurnDirectionChar('l');

                        }
                        else if (status.getdirectionChar() == 'l')
                        {
                            status.setTurnDirectionChar('b');
                        }
                        else if (status.getdirectionChar() == 'r')
                        {
                            status.setTurnDirectionChar('f');
                        }
                        else if (status.getdirectionChar() == 'b')
                        {
                            status.setTurnDirectionChar('r');
                        }
                    }
                    else
                    {
                        status.setIfLocked(false);

                        if (status.getdirectionChar() == 'f')
                        {
                            status.setdirectionChar('l');
                            status.setdirectionVector(Vector3.left);
                        }
                        else if (status.getdirectionChar() == 'l')
                        {
                            status.setdirectionChar('b');
                            status.setdirectionVector(Vector3.back);
                        }
                        else if (status.getdirectionChar() == 'r')
                        {
                            status.setdirectionChar('f');
                            status.setdirectionVector(Vector3.forward);
                        }
                        else if (status.getdirectionChar() == 'b')
                        {
                            status.setdirectionChar('r');
                            status.setdirectionVector(Vector3.right);
                        }
                    }
                }
                else
                {
                    friction.Play();
                    status.setspeed(status.getspeed() / 4);
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                if (!pastMidPoint() && hasChildOnSides('r'))
                {
                    turn.Play();
                    if (!status.getIflocked())
                    {
                        status.setIfTurning(true);
                        if (status.getdirectionChar() == 'f')
                        {
                            status.setTurnDirectionChar('r');
                        }
                        else if (status.getdirectionChar() == 'l')
                        {
                            status.setTurnDirectionChar('f');
                        }
                        else if (status.getdirectionChar() == 'r')
                        {
                            status.setTurnDirectionChar('b');
                        }
                        else if (status.getdirectionChar() == 'b')
                        {
                            status.setTurnDirectionChar('l');
                        }
                    }
                    else
                    {
                        status.setIfLocked(false);
                        if (status.getdirectionChar() == 'f')
                        {
                            status.setdirectionChar('r');
                            status.setdirectionVector(Vector3.right);
                        }
                        else if (status.getdirectionChar() == 'l')
                        {
                            status.setdirectionChar('f');
                            status.setdirectionVector(Vector3.forward);
                        }
                        else if (status.getdirectionChar() == 'r')
                        {
                            status.setdirectionChar('b');
                            status.setdirectionVector(Vector3.back);
                        }
                        else if (status.getdirectionChar() == 'b')
                        {
                            status.setdirectionChar('l');
                            status.setdirectionVector(Vector3.left);
                        }
                    }
                }
                else
                {
                    friction.Play();
                    status.setspeed(status.getspeed() / 4);
                }
            }
        }
        else
        {
            if (pastMidPoint())
            {
                player.transform.position = midPoint(true);
                status.setdirectionChar(status.getTurnDirectionChar());
                if (status.getdirectionChar() == 'f')
                {
                    status.setdirectionVector(Vector3.forward);
                }
                else if (status.getdirectionChar() == 'l')
                {
                    status.setdirectionVector(Vector3.left);
                }
                else if (status.getdirectionChar() == 'r')
                {
                    status.setdirectionVector(Vector3.right);
                }
                else if (status.getdirectionChar() == 'b')
                {
                    status.setdirectionVector(Vector3.back);
                }
                status.setIfTurning(false);
            }
        }
    }
    public void enqueuePath(pathnode node)
    {
        pathqueue.Enqueue(node);
    }
    public Queue<pathnode> getQueue()
    {
        return this.pathqueue;
    }
}
