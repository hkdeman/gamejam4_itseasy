using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RandomSample : MonoBehaviour
{
	public Text play;
	public Text quit;
    public Text menu;
	
	// Use this for initialization
	void Start ()
	{
		play.text = "Retry";
		quit.text = "Quit";
        menu.text = "Menu";
		
		InvokeRepeating("shuffle", 0f, 0.1f);
	}

	private void shuffle()
	{
		play.text = Shuffle.StringMixer(play.text);
		quit.text = Shuffle.StringMixer(quit.text);
        menu.text = Shuffle.StringMixer(menu.text);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
