using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {

    float sceneTimer = 0;
    private GameObject soundManager;
	// Use this for initialization
	void Start () {
        soundManager = GameObject.Find("MusicPlayer");
        Debug.Log(soundManager == null);
        StartCoroutine(soundManager.GetComponent<SoundControl>().Crescendo());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void loadScene(int scene)
	{
        // decresendo music before loading scene
        StartCoroutine(soundManager.GetComponent<SoundControl>().Decrescendo());
		SceneManager.LoadScene(scene);
	}

	public void quit()
	{
		Application.Quit();
	}
}
