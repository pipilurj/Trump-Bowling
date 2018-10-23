using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pointercounter : MonoBehaviour {
    private int count;
    public Text countText;
	void Start () {
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
        setCounttext();
	}
    public void increaseCount()
    {
        count++;
    }
    public int getCount()
    {
        return count;
    }
    void setCounttext()
    {
        if(count == 0)
        {
            countText.text = "Good luck! Bring down as many as you can!\n";
        }else if(count == 1)
        {
            countText.text = "1 Trump is down!\n";
        }
        else
        {
            countText.text = count.ToString() + " Trumps are down!\n";
        }
    }
}
