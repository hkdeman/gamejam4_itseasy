using System.Collections;
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

	public void loadScene(int scene)
	{
		SceneManager.LoadScene(scene);
	}

	public void quit()
	{
		Application.Quit();
	}
}
