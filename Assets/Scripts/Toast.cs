using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toast : MonoBehaviour
{


	private Animator am;
	
	// Use this for initialization
	void Start ()
	{
		am = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void createToast()
	{
		am.SetTrigger("created");
	}
	
	
}
