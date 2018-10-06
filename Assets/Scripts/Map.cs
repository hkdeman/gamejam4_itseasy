using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

	Tile[,] map = new Tile [10, 2];

    private Character myCharacter;
    private int SCALE = 2;
    private int ROWS = 10;
    private int COLS = 2;

    public GameObject tile;

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
		Debug.Log(myCharacter.myPosition.ToString());
	}

	public void createMap()
	{
        for (int z = 0; z < ROWS * SCALE; z += SCALE)
		{
            for (int x = 0; x < COLS * SCALE; x += SCALE)
			{
                //map[y, x] = new Tile(new Position(x, y));
                Instantiate(tile, new Vector3(x, 0, z), tile.transform.rotation);
			}
		}

		 
	}

	public void showMap()
	{
//		for (int i = 0; i < map.GetLength(1); ++i)
//		{
//			for (int j = 0; j < map.GetLength(0); ++j)
//			{
//				Debug.Log(map[j, i].position.ToString());
//			}
//		}
	}

	public bool left()
	{
        //		try
        //		{
        //			if (map[myCharacter.myPosition.y, myCharacter.myPosition.x - 1] == null)
        //			{
        //				Debug.Log("Don't pass");
        //				rotate("left");
        //				return false;
        //			}

        //			Debug.Log(("Move"));
        //			myCharacter.moveLeft();
        //			return true;
        //		}

        //		catch (IndexOutOfRangeException e)
        //		{
        //			Debug.Log("Can't move");
        //			rotate("left");
        //			return false;
        //		}
        return false;
	}
	
	public bool right()
	{
        //		try
        //		{			
        ////			Debug.Log("Character : " + myCharacter.myPosition.ToString());


        //		if (map[myCharacter.myPosition.y, myCharacter.myPosition.x + 1] == null)
        //		{
        //			Debug.Log("Don't pass");
        //			rotate("right");
        //			return false;
        //		}

        //		Debug.Log(("Pass"));
        //		myCharacter.moveRight();
        //		Debug.Log(myCharacter.myPosition.ToString());
        //		return true;
        //	}

        //	catch (IndexOutOfRangeException e)
        //	{
        //		Debug.Log("Can't move");
        //		rotate("right");
        //		return false;
        //	}
        return false;

    }

    public bool down()
	{
        //	try
        //	{
        //		if (map[myCharacter.myPosition.y + 1, myCharacter.myPosition.x] == null)
        //		{
        //			Debug.Log("Don't pass");
        //			rotate("down");
        //			return false;
        //		}

        //		Debug.Log(("Pass"));
        //		myCharacter.moveDown();
        //		return true;
        //	}

        //	catch (IndexOutOfRangeException e)
        //	{
        //		Debug.Log("Can't move");
        //		rotate("down");
        //		return false;
        //	}
        return false;

    }

    public bool up()
	{
        //	try
        //	{
        //		if (map[myCharacter.myPosition.y - 1, myCharacter.myPosition.x] == null)
        //		{
        //			Debug.Log("Don't pass");
        //			rotate("up");
        //			return false;
        //		}

        //		Debug.Log(("Pass"));
        //		myCharacter.moveTop();
        //		return true;
        //	}

        //	catch (IndexOutOfRangeException e)
        //	{
        //		Debug.Log("Can't move");
        //		rotate("up");
        //		return false;
        //	}
        return false;

    }

    private void rotate(string direction)
	{
	//	switch (direction)
	//	{
	//		case "left":
	//			//rotate left
	//			Debug.Log("Rotate left !");
	//			break;
	//		case "right":
	//			//rotate right
	//			Debug.Log("Rotate right !");
	//			break;
	//		case "up":
	//			//rotate up
	//			Debug.Log("Rotate up !");
	//			break;
	//		case "down":
	//			//rotate down
	//			Debug.Log("Rotate down !");
	//			break;
			
	//	}
	}
}
