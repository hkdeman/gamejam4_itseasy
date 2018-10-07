using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{

    private new AudioSource audio;
    public float decMod; // value to control the decreasing volume
    float fadeTimer = 0f;
    public float creMod; // value to control the increasing volume

    // Use this for initialization
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        audio.volume = 0.05f;
        audio.Play();
        audio.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Crescendo()
    {
        if (fadeTimer <= 0)
        {
            audio.volume += creMod;
            fadeTimer = 1f;
        } else
        {
            fadeTimer -= 0.1f;
        }
    }

    public bool isMax() { return audio.volume >= 1; }
    public bool isMin() { return audio.volume <= 0; }

    public void Decrescendo()
    {
        if (fadeTimer <= 0)
        {
            audio.volume -= decMod; //audio.volume * decMod;
            fadeTimer = 1f;
        } else
        {
            fadeTimer -= 0.1f;
        }
    }
}
