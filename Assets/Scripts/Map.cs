using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{


    public GameObject myCharacter;
    private int SCALE = 2;
    private int ROWS = 10;
    private int COLS = 4;

	private GameObject[,] map;
	
    public GameObject tile;

	// Use this for initialization
	void Start()
	{
		map = new GameObject [ROWS, COLS];
		
		createMap();
//		right();
		showMap();
        //		myCharacter = new Character(new Position(1, 1));


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
//		Debug.Log(myCharacter.myPosition.ToString());
	}

	public void createMap()
	{
        for (int z = 0; z < ROWS * SCALE; z += SCALE)
		{
            for (int x = 0; x < COLS * SCALE; x += SCALE)
			{
				if (x != 0 && x != 4 && z != ROWS * SCALE - 2)
					continue;
                map[Mathf.RoundToInt(z / SCALE),Mathf.RoundToInt(x / SCALE)] = Instantiate(tile, new Vector3(x, 0, z), tile.transform.rotation);
			}
		}

		 
	}

	public void showMap()
	{
		for (int z = 0; z < ROWS * SCALE; z += SCALE)
		{
			for (int x = 0; x < COLS * SCALE; x += SCALE)
			{
				Debug.Log(map[z / SCALE, x / SCALE].transform.position);
			}
		}
	}

	public bool left()
	{
		
		try
		{			
			
			if (map[Mathf.RoundToInt(myCharacter.gameObject.transform.position.z)/SCALE, Mathf.RoundToInt(myCharacter.gameObject.transform.position.x - SCALE)/SCALE] == null)
			{
				Debug.Log("Don't pass");
				rotate("left");
				return false;
			}

			Debug.Log(("Pass"));
			rotate("left");
			myCharacter.GetComponent<Character>().moveLeft();
		
			return true;
		}

		catch (IndexOutOfRangeException e)
		{
			Debug.Log("Can't move");
			rotate("left");
			return false;
		}
	}
	
	public bool right()
	{
		
		try
		{
		Debug.Log(Mathf.RoundToInt(myCharacter.gameObject.transform.position.x) / SCALE);
			
		if (map[Mathf.RoundToInt(myCharacter.gameObject.transform.position.z)/SCALE, Mathf.RoundToInt(myCharacter.gameObject.transform.position.x + SCALE)/SCALE] == null)
		{
			Debug.Log("Don't pass");
			rotate("right");
			return false;
		}

		Debug.Log(("Pass"));
		rotate("right");
		myCharacter.GetComponent<Character>().moveRight();
		
		return true;
	}

	catch (IndexOutOfRangeException e)
	{
		Debug.Log("Can't move");
		rotate("right");
		return false;
	}
    }

	public bool down()
	{
		
		try
		{			
			if (map[Mathf.RoundToInt(myCharacter.gameObject.transform.position.z - SCALE)/SCALE, Mathf.RoundToInt(myCharacter.gameObject.transform.position.x)/SCALE] == null)
			{
				Debug.Log("Don't pass");
				rotate("down");
				return false;
			}

			Debug.Log(("Pass"));
			rotate("down");
			myCharacter.GetComponent<Character>().moveDown();
		
			return true;
		}

		catch (IndexOutOfRangeException e)
		{
			Debug.Log("Can't move");
			rotate("down");
			return false;
		}
	}

	public bool up()
	{
		try
		{			
			if (map[Mathf.RoundToInt(myCharacter.gameObject.transform.position.z + SCALE)/SCALE, Mathf.RoundToInt(myCharacter.gameObject.transform.position.x)/SCALE] == null)
			{
				Debug.Log("Don't pass");
				rotate("up");
				return false;
			}

			Debug.Log(("Pass"));
			rotate("up");
			myCharacter.GetComponent<Character>().moveUp();
		
			return true;
		}

		catch (IndexOutOfRangeException e)
		{
			Debug.Log("Can't move");
			rotate("up");
			return false;
		}
	}

    private void rotate(string direction)
	{
		switch (direction)
		{
			case "left":
				//rotate left
				myCharacter.transform.eulerAngles = new Vector3(0, 180, 0);
				break;
			case "right":
				//rotate right
				myCharacter.transform.eulerAngles = new Vector3(0, 0, 0);
				break;
			case "up":
				//rotate up
				myCharacter.transform.eulerAngles = new Vector3(0, -90, 0);
				break;
			case "down":
				//rotate down
				myCharacter.transform.eulerAngles = new Vector3(0, 90, 0);
				break;
			
		}
	}

	public bool CheckWinCondition()
	{
		for (int z = 0; z < ROWS * SCALE; z += SCALE)
        		{
        			for (int x = 0; x < COLS * SCALE; x += SCALE)
			        {
				        if (!map[z, x].GetComponent<Tile>().status)
					        return false;
			        }
        		}

		return true;
	}
}
