using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {

    float sceneTimer = 0;
    private GameObject soundManager;
    int scene = -1;
    private bool shouldswitch = false;
    
    // Use this for initialization
	void Start () {
        soundManager = GameObject.Find("MusicPlayer");
        StartCoroutine(soundManager.GetComponent<SoundControl>().Crescendo());
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (shouldswitch && soundFade() && scene != -1)
        {
            SceneManager.LoadScene(scene);
        }
	}

    public bool soundFade()
    {
        SoundControl control = soundManager.GetComponent<SoundControl>();
        if (!control.isFinished())
        {
            control.Decrescendo();

            return false;
        } else
        {
            return true;
        }
    }

	public void loadScene(int scene)
	{
        StopCoroutine(soundManager.GetComponent<SoundControl>().Crescendo());
        this.scene = scene;
        shouldswitch = true;
	}

	public void quit()
	{
		Application.Quit();
	}
}
