using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float time = 60.0f; // in seconds

    public Text UITime;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        DownBy(1);
		UITime.text = time.ToString().Substring(0, 4);
        if (time <= 0)
        {
            // do whatever needs to happen when the game is over
            Debug.Log("under 0: " + time);
        }
    }

    public void DownBy(float amount)
    {
	    Debug.Log("Down by " + amount);
        time -= Time.deltaTime * amount;
    }
    
    

}
