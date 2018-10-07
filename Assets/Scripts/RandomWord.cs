using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RandomWord : MonoBehaviour
{
	public Text play;
//	public Text options;
	public Text quit;
	
	// Use this for initialization
	void Start ()
	{
		play.text = "Play";
		quit.text = "Quit";
		
		InvokeRepeating("shuffle", 0f, 0.1f);
	}

	private void shuffle()
	{
		play.text = Shuffle.StringMixer(play.text);
		quit.text = Shuffle.StringMixer(quit.text);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
