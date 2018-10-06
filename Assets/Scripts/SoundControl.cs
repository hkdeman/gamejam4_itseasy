using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{

    private new AudioSource audio;
    public float volMod = 0.01f;
    // Use this for initialization
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        audio.Play();
        audio.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Crescendo()
    {
        // this will crescendo the audio file after going to a new scene
    }

    void Decrescendo()
    {
        // this will decrescendo the audio file before going to the next scene
        for (float x = audio.volume; x > 0; x--)
        {
            audio.volume -= audio.volume * volMod;
            Debug.Log(audio.volume);
        }
    }
}
