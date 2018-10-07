using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundControl : MonoBehaviour
{

    private new AudioSource audio;
    public AudioClip regular;
    public AudioClip hurryTFU;

    private bool intenseMode = false;

    public float decMod; // value to control the decreasing volume
    float fadeTimer = 0f;
    public float creMod; // value to control the increasing volume
    private GameObject timer;

    // Use this for initialization
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        timer = GameObject.Find("Timer");
        audio.volume = 0.05f;
        audio.clip = regular;
        audio.Play();
        audio.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (timer != null)
        {
            if (timer.GetComponent<TimerManager>().getRemainingTime() <= 40 && !intenseMode) { 
                audio.clip = hurryTFU;
                audio.volume = 1.0f;
                audio.Play();
                intenseMode = !intenseMode;
            }
        }
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
            audio.volume -= decMod;
            fadeTimer = 1f;
        } else
        {
            fadeTimer -= 0.1f;
        }
    }
}
