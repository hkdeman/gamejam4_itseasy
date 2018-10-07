using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevelMap : MonoBehaviour
{


    public GameObject myCharacter;
    public GameObject particlesController;
    public int SCALE = 2;
    public int ROWS;
    public int COLS;
    public TimerManager timer;
    public int xClockPos, zClockPos;
    public int currentLevel;

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
        map = new GameObject[ROWS, COLS];
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
                        map[z, x] = (GameObject)Instantiate(tile, new Vector3(x * SCALE, 0, z * SCALE), tile.transform.rotation);
                    }

                    if (clockPosition.x == x && clockPosition.z == z)
                    {
                        spawnedClock = (GameObject)Instantiate(clock, new Vector3(x * SCALE, 2f, z * SCALE), clock.transform.rotation);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
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
                    rotate("left");
                    return false;
                }
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
                    rotate("right");
                    return false;
                }

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
                    rotate("down");
                    return false;
                }

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
                    rotate("up");
                    return false;
                }

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
            rotate("up");
            return false;
        }
    }

    private void CheckIfClockThere()
    {
        if (clockStatus)
        {
            if ((Mathf.RoundToInt(clockPosition.x) == Mathf.RoundToInt(currentPosition.x)) && (Mathf.RoundToInt(clockPosition.z) == Mathf.RoundToInt(currentPosition.z)))
            {
                Transform t = spawnedClock.transform;
                int alreadyX = Mathf.RoundToInt(spawnedClock.transform.position.x);
                int alreadyZ = Mathf.RoundToInt(spawnedClock.transform.position.z);
                float y = spawnedClock.transform.position.y;
                Destroy(spawnedClock);
                Instantiate(particlesController, t.position, t.rotation);
                timer.time += 15.0f;
                int x = GetAValueApartFrom(0, COLS - 1, alreadyX) * SCALE;
                int z = GetAValueApartFrom(0, COLS - 1, alreadyZ) * SCALE;
                spawnedClock = Instantiate(clock,
                                           new Vector3(
                                               x,
                                               y,
                                               z),
                                           clock.transform.rotation);

            }
        }
    }



    private int GetAValueApartFrom(int min, int max, int avoid)
    {
        int value = 0;
        while (true)
        {
            value = UnityEngine.Random.Range(min, max - 1);
            if (value != avoid) break;
        }
        return value;
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
