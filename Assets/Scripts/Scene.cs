﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Scene : MonoBehaviour {

    float sceneTimer = 0;
    public GameObject soundManager;
    private SoundControl control;
    int scene = -1;
    private bool shouldswitch = false;
    private bool isInc = true;
    
    // Use this for initialization
	void Start () {
        soundManager = GameObject.Find("MusicPlayer");
        control = soundManager.GetComponent<SoundControl>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (shouldswitch && soundFade() && scene != -1)
        {
            SceneManager.LoadScene(scene);
        } else if (!control.isMax() && isInc)
        {
            control.Crescendo();
        }
	}

    public bool soundFade()
    {
        if (!control.isMin())
        {
            control.Decrescendo();
            return false;
        } else
        {
            return true;
        }
    }

    public void quickLoad(int scene)
    {
        TimerManager.SetStatus(true);
        try {
            GameObject.FindWithTag("Timer").GetComponent<TimerManager>().time = 180.0f;
        } catch(Exception e) {

        }
        SceneManager.LoadScene(scene);
    }

	public void quit()
	{
        Debug.Log("quit");
		Application.Quit();
	}
}
