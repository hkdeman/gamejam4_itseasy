﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {

    float sceneTimer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void play()
	{
		SceneManager.LoadScene(1);
	}

	public void quit()
	{
		Application.Quit();
	}
}
