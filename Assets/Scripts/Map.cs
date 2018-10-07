using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Map : MonoBehaviour
{


    public GameObject myCharacter;
    public int SCALE = 2;
    public int ROWS;
    public int COLS;
    public int xClockPos, zClockPos;
    public int xCoinPos, zCoinPos;
    public int currentLevel;
    public Texture2D WIN, LOSE;

    private GameObject[,] map;
    public int[] levelOneMap;

	
    public GameObject tile;
    public GameObject clock;
    public GameObject coin;

	private bool clockStatus = true;

    Vector3 clockPosition;
    Vector3 coinPosition;

    public int score = 0;
    public Text text;

    // Use this for initialization
	void Start()
	{
		map = new GameObject [ROWS, COLS];
        clockPosition = new Vector3(xClockPos, 0, zClockPos);
        coinPosition = new Vector3(xCoinPos, 0, zCoinPos);
        createMap();
		showMap();
	}

	public void createMap()
	{
        try
        {
            for (int z = 0; z < ROWS; z += 1)
            {
                for (int x = 0; x < COLS; x += 1)
                {
                    int pos = x + ROWS * z;
                    if (levelOneMap[pos] == 1)
                    {
                        map[z, x] = (GameObject) Instantiate(tile, new Vector3(x * SCALE, 0, z * SCALE), tile.transform.rotation);
                    }

                    if (clockPosition.x == x && clockPosition.z == z)
                    {
                        Instantiate(clock, new Vector3(x * SCALE, 2f, z * SCALE), clock.transform.rotation);
                    }

                    if(coinPosition.x == x && coinPosition.z == z) {
                        Instantiate(coin, new Vector3(x * SCALE, 2f, z * SCALE), coin.transform.rotation);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        /*for (int z = 0; z < ROWS * SCALE; z += SCALE)
		{
            for (int x = 0; x < COLS * SCALE; x += SCALE)
			{
				if (x != 0 && x != 4 && z != ROWS * SCALE - 2)
					continue;
                map[Mathf.RoundToInt(z / SCALE),Mathf.RoundToInt(x / SCALE)] = Instantiate(tile, new Vector3(x, 0, z), tile.transform.rotation);
			}
		}*/

		 
	}

	public void showMap()
	{
		for (int z = 0; z < ROWS * SCALE; z += SCALE)
		{
			for (int x = 0; x < COLS * SCALE; x += SCALE)
			{
				//Debug.Log(map[z / SCALE, x / SCALE].transform.position);
			}
		}
	}

	public bool left()
	{

		try
		{
			if (!Character.isJumping)
			{
				if (map[Mathf.RoundToInt(myCharacter.gameObject.transform.position.z) / SCALE,
					    Mathf.RoundToInt(myCharacter.gameObject.transform.position.x - SCALE) / SCALE] == null)
				{
					Debug.Log("Don't pass");
					rotate("left");
					return false;
				}

				Debug.Log(("Pass"));
				rotate("left");
				myCharacter.GetComponent<Character>().MoveLeft();
				return true;
			}

			return false;
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
			if (!Character.isJumping)
			{
				if (map[Mathf.RoundToInt(myCharacter.gameObject.transform.position.z) / SCALE,
					    Mathf.RoundToInt(myCharacter.gameObject.transform.position.x + SCALE) / SCALE] == null)
				{
					Debug.Log("Don't pass");
					rotate("right");
					return false;
				}

				Debug.Log(("Pass"));
				rotate("right");
				myCharacter.GetComponent<Character>().MoveRight();
				return true;
			}

			return false;
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
			if (!Character.isJumping)
			{
				if (map[Mathf.RoundToInt(myCharacter.gameObject.transform.position.z - SCALE) / SCALE,
					    Mathf.RoundToInt(myCharacter.gameObject.transform.position.x) / SCALE] == null)
				{
					Debug.Log("Don't pass");
					rotate("down");
					return false;
				}

				Debug.Log(("PassDOWN"));
				rotate("down");
				myCharacter.GetComponent<Character>().MoveDown();
				return true;
			}

			return false;
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
			if (!Character.isJumping)
			{
				if (map[Mathf.RoundToInt(myCharacter.gameObject.transform.position.z + SCALE) / SCALE,
					    Mathf.RoundToInt(myCharacter.gameObject.transform.position.x) / SCALE] == null)
				{
					Debug.Log("Don't pass");
					rotate("up");
					return false;
				}

				Debug.Log(("Pass"));
				rotate("up");
				myCharacter.GetComponent<Character>().MoveUp();
				return true;
			}

			return false;
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
		if (CheckWinCondition())
		{
			Debug.Log("WIN");
		}
		
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

		foreach (var t in GameObject.FindGameObjectsWithTag("Tile"))
		{
			if (!t.GetComponent<Tile>().status)
			{
				return false;
			}
		}
	
		return true;
	}

}
