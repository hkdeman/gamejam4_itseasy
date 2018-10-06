using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour {

    public float time = 60.0f; // in seconds

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        DownBy(1);
        if (time <= 0)
        {
            // do whatever needs to happen when the game is over
            Debug.Log("under 0: " + time);
        }
    }

    void DownBy(float amount)
    {
        time -= Time.deltaTime * amount;
    }

}
