using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class random_keys : MonoBehaviour {

    private List<string> alpha = new List<string>();

    // Use this for initialization
    void Start () {
        //wtf
        alpha.Add("w");
        alpha.Add("a");
        alpha.Add("s");
        alpha.Add("d");

        var rand = new System.Random();
        alpha = alpha.OrderBy(x => rand.Next()).ToList();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(alpha[0]))
        {
            // call up() here
        } else if (Input.GetKeyDown(alpha[1]))
        {
            // call down() here
        } else if (Input.GetKeyDown(alpha[2]))
        {
            // call left() here
        } else if (Input.GetKeyDown(alpha[3]))
        {
            // call right() here
        }
    }

}
