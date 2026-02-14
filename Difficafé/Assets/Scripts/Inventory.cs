using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	Vector3 cameraDistanceVector = new Vector3();

	[SerializeField] float movementSpeed;
	[SerializeField] float movementDistance;
	public GameObject[] inventoryItems;
	[NonSerialized] [NonReorderable] public bool moving;
    int movementDirection = -1;
	float distanceMoved = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		gameObject.transform.position += new Vector3(movementDistance, 0);
        moving = false;

        cameraDistanceVector = gameObject.transform.position - GameObject.FindWithTag("MainCamera").transform.position;
	}

    // Update is called once per frame
    void Update()
    {
		gameObject.transform.position = GameObject.FindWithTag("MainCamera").transform.position + cameraDistanceVector;

		CheckInventoryMovement();
	}

	void CheckInventoryMovement()
	{
		if (moving && distanceMoved < movementDistance)
		{
			gameObject.transform.position += new Vector3(movementDirection * movementSpeed, 0);
			distanceMoved += movementSpeed;
			cameraDistanceVector = gameObject.transform.position - GameObject.FindWithTag("MainCamera").transform.position;
		}
		else if (moving)
		{
			moving = false;
			movementDirection *= -1;
			gameObject.transform.position += new Vector3(
				gameObject.transform.position.x - Mathf.Abs(distanceMoved - movementDistance) * movementDirection, 
				gameObject.transform.position.y);
			distanceMoved = 0;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{

	}

	public void SwitchSide()
	{
		movementDirection *= -1;
		cameraDistanceVector -= new Vector3(2 * (gameObject.transform.position.x - GameObject.FindWithTag("MainCamera").transform.position.x), 0);
		gameObject.transform.position -= new Vector3(2 * (gameObject.transform.position.x - GameObject.FindWithTag("MainCamera").transform.position.x), 0);
	}
}
