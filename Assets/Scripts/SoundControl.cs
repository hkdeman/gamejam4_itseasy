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

    public IEnumerator Crescendo()
    {
        while (audio.volume < 1)
        {
            audio.volume += audio.volume * creMod;
            yield return null;
        }
    }

    public bool isFinished() { return audio.volume <= 0; }

    public void Decrescendo()
    {
        if (fadeTimer <= 0)
        {
            audio.volume -= 0.1f; //audio.volume * decMod;
            fadeTimer = 1f;
        } else
        {
            fadeTimer -= 0.1f;
        }
    }
}
