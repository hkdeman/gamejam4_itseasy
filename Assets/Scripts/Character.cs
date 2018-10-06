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
            SetIsJumping(true);
            animator.SetBool("IsJumping", isJumping);

            for (float i = 0; i < RANGE; i += STEPS)
            {
                if (i < RANGE / 2)
                {
                    gameObject.transform.position += new Vector3(-1 * STEPS * RANGE_TO_SCALE_RATIO, STEPS, 0);
                }
                else
                {
                    gameObject.transform.position += new Vector3(-1 * STEPS * RANGE_TO_SCALE_RATIO, RANGE - STEPS, 0);
                }
            }
        }
    }

	public void MoveRight()
	{
        if (!isJumping)
        {
            SetIsJumping(true);
            animator.SetBool("IsJumping", isJumping);

            for (float i = 0; i < RANGE; i += STEPS)
            {
                if (i < RANGE / 2)
                {
                    gameObject.transform.position += new Vector3(STEPS * RANGE_TO_SCALE_RATIO, STEPS, 0);
                }
                else
                {
                    gameObject.transform.position += new Vector3(STEPS * RANGE_TO_SCALE_RATIO, RANGE - STEPS, 0);
                }
            }
        }
    }
	
	public void MoveDown()
	{
        if (!isJumping)
        {
            SetIsJumping(true);
            animator.SetBool("IsJumping", isJumping);

            for (float i = 0; i < RANGE; i += STEPS)
            {
                if (i < RANGE / 2)
                {
                    gameObject.transform.position += new Vector3(0, STEPS, -1 * STEPS * RANGE_TO_SCALE_RATIO);
                }
                else
                {
                    gameObject.transform.position += new Vector3(0, RANGE - STEPS, -1 * STEPS * RANGE_TO_SCALE_RATIO);
                }
            }
        }
    }
	
    public void MoveUp()
	{
        if (!isJumping)
        {
            SetIsJumping(true);
            animator.SetBool("IsJumping", isJumping);

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
