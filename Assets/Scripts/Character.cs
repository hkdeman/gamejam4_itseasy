using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
	public Position myPosition;


	public Character(Position myPosition)
	{
		this.myPosition = myPosition;
	}

	public void moveLeft()
	{
		myPosition.x -= 1;
	}
	
	public void moveRight()
	{
		myPosition.x += 1;	}
	
	public void moveTop()
	{
		myPosition.y -= 1;	}
	
	public void moveDown()
	{
		myPosition.y += 1;	}
	
	
	
}
