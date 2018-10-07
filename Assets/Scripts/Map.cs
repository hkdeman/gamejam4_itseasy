using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{


    public GameObject myCharacter;
    public GameObject particlesController;
    public int SCALE = 2;
    public int ROWS;
    public int COLS;
    public TimerManager timer;
    public int xClockPos, zClockPos;
    public int currentLevel;
    public Texture2D WIN, LOSE;

    private GameObject[,] map;
    public int[] levelOneMap;

	
    public GameObject tile;
    public GameObject clock;

	private bool clockStatus = true;

    Position clockPosition;
    Vector3 currentPosition;

    GameObject spawnedClock;


	// Use this for initialization
	void Start()
	{
		map = new GameObject [ROWS, COLS];
        clockPosition = new Position(xClockPos, zClockPos);
		currentPosition = myCharacter.transform.position;
	        //new Position(0, 0);
        createMap();
		showMap();
	}

	// Update is called once per frame
	void Update()
	{
		print(currentPosition);
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
                        print(clockPosition);
                        spawnedClock = (GameObject) Instantiate(clock, new Vector3(x * SCALE, 2f, z * SCALE), clock.transform.rotation);
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
				currentPosition.x -= 1;
				CheckIfClockThere();
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
				currentPosition.x += 1;
				CheckIfClockThere();
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
				currentPosition.z -= 1;
				CheckIfClockThere();
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
				currentPosition.z += 1;
				CheckIfClockThere();
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

    private void CheckIfClockThere() {
	    if (clockStatus)
	    {
		    if (clockPosition.x == currentPosition.x && clockPosition.z == currentPosition.z)
		    {
			    Transform t = spawnedClock.transform;
			    Destroy(spawnedClock);
			    Instantiate(particlesController, t.position, t.rotation);
			    timer.time += 15.0f;
			    clockStatus = false;
		    }
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
