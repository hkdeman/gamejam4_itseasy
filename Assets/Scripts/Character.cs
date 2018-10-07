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

    Animator animator;

    private float yVelocity = 0.0F;

    void Start()
    {
        STEPS = RANGE / 5;
        SetIsJumping(false);
        animator = GetComponent<Animator>();
    }

    public void MoveLeft()
	{
		if (!isJumping)
		{
			isJumping = true;
			animator.Play("Jump");
			Invoke("left", 0.4f);
		}
    }

	void left()
	{
		gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-3.175f, 3.175f, 0f);
	}

	public void MoveRight()
	{
		if (!isJumping)
		{
			isJumping = true;
			animator.Play("Jump");
			Invoke("right", 0.4f);
		}
    }

	void right()
	{
		gameObject.GetComponent<Rigidbody>().velocity = new Vector3(3.175f, 3.175f, 0f);
	}
	
	public void MoveDown()
	{
	    if (!isJumping)
	    {
	        isJumping = true;
	        animator.Play("Jump");
	        Invoke("down", 0.4f);
	    }
    }

    void down()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 3.175f, -3.175f);
    }
	
    public void MoveUp()
	{
	    if (!isJumping)
	    {
	        isJumping = true;
	        animator.Play("Jump");
	        Invoke("up", 0.4f);
	    }
	}

    private void up()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 3.175f, 3.175f);
    }

    public static void SetIsJumping(bool iJ) {
        isJumping = iJ;
    }
}
