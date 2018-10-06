using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class random_keys : MonoBehaviour
{

    public GameObject map;
    private Map myMap;
    
    private List<string> alpha = new List<string>();
    public string viableButtons; // can add viable buttons in the editor itself

    // Use this for initialization
    void Start ()
    {

        myMap = map.GetComponent<Map>();
        
        // add each character to the alpha array
        foreach (char c in viableButtons)
        {
            alpha.Add(c.ToString());
        }
        // shuffle array so the values are random, hence the buttons are random
        var rand = new System.Random();
        alpha = alpha.OrderBy(x => rand.Next()).ToList();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(alpha[0]))
        {
            myMap.up();

        } else if (Input.GetKeyDown(alpha[1]))
        {
            myMap.down();
        } else if (Input.GetKeyDown(alpha[2]))
        {
            myMap.left();
        } else if (Input.GetKeyDown(alpha[3]))
        {
            myMap.right();
        }
    }
}
