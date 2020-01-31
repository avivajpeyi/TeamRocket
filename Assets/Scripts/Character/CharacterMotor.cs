using System;
using System.Collections;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
	private Vector3 offset;

	private CharacterMaster myMaster;
	private CharacterInput myInput;
	
	public GameObject playerRenderer;
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
		myMaster = this.GetComponent<CharacterMaster>();
		myInput = this.GetComponent<CharacterInput>();
	}


	private void Update()
	{
		if (myInput.AmIReadyForInput())
		{
			if (Input.GetKey(myInput.upKey))
			{
				StartCoroutine("moveUp");
				myInput.PreventFurthurInput();
			}
			else if (Input.GetKey(myInput.downKey))
			{
				StartCoroutine("moveDown");
				myInput.PreventFurthurInput();
			}
			else if (Input.GetKey(myInput.leftKey))
			{
				StartCoroutine("moveLeft");
				myInput.PreventFurthurInput();
			}
			else if (Input.GetKey(myInput.rightKey))
			{
				StartCoroutine("moveRight");
				myInput.PreventFurthurInput();
			}
		}
	}

	IEnumerator moveUp()
	{
		myMaster.numberStepsTaken++;
		for (int i = 0; i < 90 / step; i++)
		{
			playerRenderer.transform.RotateAround(up.transform.position, Vector3.right, step);
			yield return new WaitForSeconds(speed);
		}
		center.transform.position = playerRenderer.transform.position;
		myInput.SetReadyForInput(); 
	}
	
	IEnumerator moveDown()
	{
		myMaster.numberStepsTaken++;
		for (int i = 0; i < 90 / step; i++)
		{
			playerRenderer.transform.RotateAround(down.transform.position, Vector3.left, step);
			yield return new WaitForSeconds(speed);
		}	      
		center.transform.position = playerRenderer.transform.position;
		myInput.SetReadyForInput();
	}

	
	IEnumerator moveLeft()
	{
		myMaster.numberStepsTaken++;
		for (int i = 0; i < 90 / step; i++)
		{
			playerRenderer.transform.RotateAround(left.transform.position, Vector3.forward, step);
			yield return new WaitForSeconds(speed);
		}
		center.transform.position = playerRenderer.transform.position;
		myInput.SetReadyForInput();
	}

	
	IEnumerator moveRight()
	{
		myMaster.numberStepsTaken++;
		for (int i = 0; i < 90 / step; i++)
		{
			playerRenderer.transform.RotateAround(right.transform.position, Vector3.back, step);
			yield return new WaitForSeconds(speed);
		}
		center.transform.position = playerRenderer.transform.position;
		myInput.SetReadyForInput();
	}

	
}
