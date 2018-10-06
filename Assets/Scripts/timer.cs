using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

	public Image Panel;
	public Image ButtonAgain;
	public Image ButtonQuit;
	public Text textGameOver;
	public Text textAgain;
	public Text textQuit;
    public float timeUp = 0.0f;

	private bool hasLose = false;

	public static bool status = true;

    public float time = 5.0f; // in seconds

    public Text UITime;
    
	// Use this for initialization
	void Start ()
	{
		hasLose = false;
	}
	
	// Update is called once per frame
	void Update () {
        DownBy(1);
        Upby(1);
		UITime.text = time.ToString().Substring(0, 4);
        if (time <= 0)
        {
	        Timer.status = false;
	        Lose();
        }
    }

    public float getTime()
    {
        return timeUp;
    }

    public void DownBy(float amount)
	private void Lose()
	{
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
        time += Time.deltaTime * amount;
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
