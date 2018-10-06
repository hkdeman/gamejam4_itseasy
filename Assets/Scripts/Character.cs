using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static float RANGE = 0.25f;
    public static float RANGE_TO_SCALE_RATIO = 8;
    public static float STEPS;

    public static bool isJumping;

    void Start()
    {
        STEPS = RANGE / 10;
        SetIsJumping(false);
    }

    public void moveLeft()
	{
        if (!isJumping)
            gameObject.transform.position -= new Vector3(2, 0, 0);
	}

	public void moveRight()
	{
        if (!isJumping)
            gameObject.transform.position += new Vector3(2, 0, 0);
	}
	
	public void moveDown()
	{
        if (!isJumping)
            gameObject.transform.position -= new Vector3(0, 0, 2);
	}
	
    public void moveUp()
	{
        if (!isJumping)
        {
            isJumping = true;
            for (float i = 0; i < RANGE; i += STEPS)
            {
                if (i < RANGE / 2)
                {
                    gameObject.transform.position += new Vector3(0, STEPS, STEPS * RANGE_TO_SCALE_RATIO);
                }
                else
                {
                    gameObject.transform.position += new Vector3(0, RANGE - STEPS, STEPS * RANGE_TO_SCALE_RATIO);
                }
            }
        }
    }

    public static void SetIsJumping(bool iJ) {
        isJumping = iJ;
    }

}
