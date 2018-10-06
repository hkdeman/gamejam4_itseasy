using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{

    private new AudioSource audio;
    public float decMod; // value to control the decreasing volume
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

    public IEnumerator Decrescendo()
    {
        while (audio.volume > 0)
        {
            audio.volume -= audio.volume * decMod;
            yield return null;
        }
    }
}
