using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    private AudioSource timerAudioSource;
    public AudioClip dieClip;

	public Image Panel;
	public Image ButtonAgain;
	public Image ButtonQuit;
	public Text textGameOver;
	public Text textAgain;
	public Text textQuit;
    public float timeUp = 0.0f;

	private bool hasLose = false;
    private bool hasPlayed = false;

	public static bool status = true;

    public float time = 5.0f; // in seconds

    public Text UITime;
    
	// Use this for initialization
	void Start ()
	{
        timerAudioSource = GetComponent<AudioSource>();
		hasLose = false;
	}
	
	// Update is called once per frame
	void Update () {
        DownBy(1);
        Upby(1);
		UITime.text = time.ToString().Substring(0, 4);
        if (time <= 0)
        {
	        TimerManager.status = false;
	        Lose();
        }
    }

    public float getTime()
    {
        return timeUp;
    }

    private void FixedUpdate()
    {
        if (hasLose && !hasPlayed)
        {
            
            timerAudioSource.PlayOneShot(dieClip);
            //timerAudioSource();
            hasPlayed = true;
        }
    }

    public float getRemainingTime()
    {
        return time;
    }

	private void Lose()
	{
       
		GameObject.Find("MainCharacter").GetComponent<Animator>().Play("Dead");
		
		Panel = Panel.GetComponent<Image>();
		var tempColor = Panel.color;
		tempColor.a += 0.15f * Time.deltaTime;
		Panel.color = tempColor;
		
		ButtonAgain = ButtonAgain.GetComponent<Image>();
		var tempColor1 = ButtonAgain.color;
		tempColor1.a += 0.15f * Time.deltaTime;
		ButtonAgain.color = tempColor1;
		
		ButtonQuit = ButtonQuit.GetComponent<Image>();
		var tempColor2 = ButtonQuit.color;
		tempColor2.a += 0.15f * Time.deltaTime;
		ButtonQuit.color = tempColor2;
		
		if (!hasLose)
		{
            //timerAudioSource.clip = dieClip;
            StartCoroutine(FadeTextToFullAlpha(1f, textGameOver));
			StartCoroutine(FadeTextToFullAlpha(7f, textAgain));
			StartCoroutine(FadeTextToFullAlpha(7f, textQuit));
			hasLose = true;
		}

	}

	public void DownBy(float amount)
    {
	    Debug.Log("Down by " + amount);
        time -= Time.deltaTime * amount;
    }

    public void Upby(float amount)
    {
        timeUp += Time.deltaTime * amount;
    }

	public static bool GetTimerStatus()
	{
		return status;
	}
    
	public IEnumerator FadeTextToFullAlpha(float t, Text i)
	{
		i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
		while (i.color.a < 1.0f)
		{
			i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
			yield return null;
		}
	}
	
}
