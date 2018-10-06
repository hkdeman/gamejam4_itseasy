using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

	Tile[,] map = new Tile [10, 2];

	private Character myCharacter;

	// Use this for initialization
	void Start()
	{
		createMap();
//		showMap();
		myCharacter = new Character(new Position(0, 0));
//		Debug.Log(myCharacter.myPosition.ToString());
//		right();
//		Debug.Log(myCharacter.myPosition.ToString());
//		right();
//		right();
//		down();
//		left();
//		left();
//		Debug.Log(myCharacter.myPosition.ToString());


	}

	// Update is called once per frame
	void Update()
	{
		//Debug.Log(myCharacter.myPosition.ToString());
	}

	public void createMap()
	{
		for (int y = 0; y < 10; ++y)
		{
			for (int x = 0; x < 2; ++x)
			{
				map[y, x] = new Tile(new Position(x, y));
			}
		}

		 
	}

	public void showMap()
	{
		for (int i = 0; i < map.GetLength(1); ++i)
		{
			for (int j = 0; j < map.GetLength(0); ++j)
			{
				Debug.Log(map[j, i].position.ToString());
			}
		}
	}

	public bool left()
	{
		try
		{
			
			if (map[myCharacter.myPosition.y, myCharacter.myPosition.x - 1] == null)
			{
				Debug.Log("Don't pass");
				return false;
			}

			Debug.Log(("Move"));
			myCharacter.moveLeft();
			return true;
		}

		catch (IndexOutOfRangeException e)
		{
			Debug.Log("Can't move");
			return false;
		}
	}
	
	public bool right()
	{
		try
		{			
//			Debug.Log("Character : " + myCharacter.myPosition.ToString());
			
			
			if (map[myCharacter.myPosition.y, myCharacter.myPosition.x + 1] == null)
			{
				Debug.Log("Don't pass");
				return false;
			}

			Debug.Log(("Pass"));
			myCharacter.moveRight();
			Debug.Log(myCharacter.myPosition.ToString());
			return true;
		}

		catch (IndexOutOfRangeException e)
		{
			Debug.Log("Can't move");
			return false;
		}
	}
	
	public bool down()
	{
		try
		{
			if (map[myCharacter.myPosition.y + 1, myCharacter.myPosition.x] == null)
			{
				Debug.Log("Don't pass");
				return false;
			}

			Debug.Log(("Pass"));
			myCharacter.moveDown();
			return true;
		}

		catch (IndexOutOfRangeException e)
		{
			Debug.Log("Can't move");
			return false;
		}
	}
	
	public bool up()
	{
		try
		{
			if (map[myCharacter.myPosition.y - 1, myCharacter.myPosition.x] == null)
			{
				Debug.Log("Don't pass");
				return false;
			}

			Debug.Log(("Pass"));
			myCharacter.moveTop();
			return true;
		}

		catch (IndexOutOfRangeException e)
		{
			Debug.Log("Can't move");
			return false;
		}
	}
}
