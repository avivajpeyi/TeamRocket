using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
	private Vector3 offset;
	public GameObject player;
	public GameObject center;
	public GameObject up;
	public GameObject down;
	public GameObject left;
	public GameObject right;

	public int step = 9;
	public float speed = 0.01f;
	private bool input = true;
	
	void Start()
	{
		
	}


	private void Update()
	{
		if (input==true)
		{
			if (Input.GetKey(KeyCode.UpArrow))
			{
				StartCoroutine("moveUp");
				input = false;
			}
			else if (Input.GetKey(KeyCode.DownArrow))
			{
				StartCoroutine("moveDown");
				input = false;
			}
			else if (Input.GetKey(KeyCode.LeftArrow))
			{
				StartCoroutine("moveLeft");
				input = false;
			}
			else if (Input.GetKey(KeyCode.RightArrow))
			{
				StartCoroutine("moveRight");
				input = false;
			}
		}
	}

	IEnumerator moveUp()
	{
		for (int i = 0; i < 90 / step; i++)
		{
			player.transform.RotateAround(up.transform.position, Vector3.right, step);
			yield return new WaitForSeconds(speed);
		}
		center.transform.position = player.transform.position;
		input = true;
	}
	
	IEnumerator moveDown()
	{
		for (int i = 0; i < 90 / step; i++)
		{
			player.transform.RotateAround(down.transform.position, Vector3.left, step);
			yield return new WaitForSeconds(speed);
		}
		center.transform.position = player.transform.position;
		input = true;
	}

	
	IEnumerator moveLeft()
	{
		for (int i = 0; i < 90 / step; i++)
		{
			player.transform.RotateAround(left.transform.position, Vector3.forward, step);
			yield return new WaitForSeconds(speed);
		}
		center.transform.position = player.transform.position;
		input = true;
	}

	
	IEnumerator moveRight()
	{
		for (int i = 0; i < 90 / step; i++)
		{
			player.transform.RotateAround(right.transform.position, Vector3.back, step);
			yield return new WaitForSeconds(speed);
		}
		center.transform.position = player.transform.position;
		input = true;
	}

	
}
