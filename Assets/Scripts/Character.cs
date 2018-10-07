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
            SetIsJumping(true);
            animator.SetBool("IsJumping", isJumping);
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-3.175f, 3.175f, 0f);
        }
    }

	public void MoveRight()
	{
        if (!isJumping)
        {
            SetIsJumping(true);
            animator.SetBool("IsJumping", isJumping);
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(3.175f, 3.175f, 0f);

        }
    }
	
	public void MoveDown()
	{
        if (!isJumping)
        {
            SetIsJumping(true);
            animator.SetBool("IsJumping", isJumping);
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 3.175f, -3.175f);

        }
    }
	
    public void MoveUp()
	{
        if (!isJumping)
        {
            SetIsJumping(true);
            animator.SetBool("IsJumping", isJumping);
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, 3.175f, 3.175f);

        }
    }
    
    public IEnumerator uu()
    {
        float newPosition = Mathf.SmoothDamp(gameObject.transform.position.y, gameObject.transform.position.y + 2, ref yVelocity, 0.3f);
        gameObject.transform.position += new Vector3(gameObject.transform.position.x, newPosition, newPosition);
        yield return null;
        
        
    }

    public static void SetIsJumping(bool iJ) {
        isJumping = iJ;
    }
}
