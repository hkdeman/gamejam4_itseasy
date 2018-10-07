using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        //StartCoroutine(soundManager.GetComponent<SoundControl>().Crescendo());
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (shouldswitch && soundFade() && scene != -1)
        {
            Debug.Log("switching");
            SceneManager.LoadScene(scene);
        } else if (!control.isMax() && isInc)
        {
            Debug.Log("increasing");
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

	public void loadScene(int scene)
	{
        // StopCoroutine(soundManager.GetComponent<SoundControl>().Crescendo());
        this.scene = scene;
        shouldswitch = true;
        isInc = false;
	}

	public void quit()
	{
		Application.Quit();
	}
}
