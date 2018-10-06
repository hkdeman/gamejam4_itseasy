using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	


//	public Character(Position myPosition)
//	{
//		this.myPosition = myPosition;
//	}
//
	public void moveLeft()
	{
		gameObject.transform.position -= new Vector3(2, 0, 0); 
	}

	public void moveRight()
	{
		gameObject.transform.position += new Vector3(2, 0, 0);
	}
	
	public void moveDown()
	{
		gameObject.transform.position -= new Vector3(0, 0, 2);
	}
	
	public void moveUp()
	{
		gameObject.transform.position += new Vector3(0, 0, 2);
	}
	
	
	
}
