using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {
    public GameObject tile;
    private string[] platformLayout = {
            "* *************",
            "* *   *       *",
            "* *   *   *   *",
            "* *   *   *   *",
            "* *********   *",
            "*     *   *   *",
            "*******   *****",
            "      *        ",
            "****  *        ",
            "*  *  *********",
            "*  *       *  *",
            "*  *****   *  *",
            "*  *   *   *  *",
            "*  *   *   *  *",
            "** *   *   *  *",
            " * *   *   *  *",
            " * *** *****  *",
            " *   *        *",
            " *   *  *******",
            " *   ****      " };

    // Use this for initialization
    void Start()
    {
        for(int i =0; i<platformLayout.Length; i++)
        {
            for(int j=0; j<platformLayout[i].Length; j++)
            {
                if(platformLayout[i][j] == '*')
                {
                    Instantiate(tile,new Vector3(j*10,0,i*10),Quaternion.identity);
                }
            }
        }
    }


    // Update is called once per frame
    void Update () {
		
	}
    public string[] getPlatform()
    {
        return platformLayout;
    }
}
