using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	Vector3 cameraDistanceVector = new Vector3();

	[SerializeField] float movementSpeed;
	[SerializeField] float movementDistance;

	[NonSerialized][NonReorderable] public GameObject[] inventoryItems = { null, null, null, null };
	[NonReorderable] public GameObject[] inventorySlots;
	[NonSerialized][NonReorderable] Vector3[] inventorySlotOffsets;

	[NonSerialized] public bool moving;
	[NonSerialized] public bool isRight;

	int movementDirection = -1;
	float distanceMoved = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
	{
		isRight = true;

		inventorySlotOffsets = new Vector3[inventorySlots.Length];
		for (int i = 0; i < inventorySlots.Length; ++i)
		{
			inventorySlotOffsets[i] = new Vector3(inventorySlots[i].transform.position.x - gameObject.transform.position.x,
				inventorySlots[i].transform.position.y - gameObject.transform.position.y);
		}

		gameObject.transform.position += new Vector3(movementDistance, 0);
        moving = false;

        cameraDistanceVector = gameObject.transform.position - GameObject.FindWithTag("MainCamera").transform.position;
	}

    // Update is called once per frame
    void LateUpdate()
    {
		gameObject.transform.position = GameObject.FindWithTag("MainCamera").transform.position + cameraDistanceVector;

		CheckInventoryMovement();

		gameObject.transform.position = GameObject.FindWithTag("MainCamera").transform.position + cameraDistanceVector;

		for (int i = 0; i < inventorySlots.Length; ++i)
		{
			inventorySlots[i].transform.position =
				new Vector3(gameObject.transform.position.x + inventorySlotOffsets[i].x, gameObject.transform.position.y + inventorySlotOffsets[i].y, 0);
			
			if (inventoryItems[i] is not null && !inventoryItems[i].GetComponent<Draggable>().dragging) inventoryItems[i].transform.position =
					new Vector3(gameObject.transform.position.x + inventorySlotOffsets[i].x, gameObject.transform.position.y + inventorySlotOffsets[i].y, 0);
		}
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

	public void FlipDirection()
	{
		movementDirection *= -1;
		distanceMoved = movementDistance - distanceMoved;
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Draggable"))
		{
			collision.gameObject.GetComponent<Draggable>().DefaultPosition = FindClosestFreeSlot(collision.gameObject);
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Draggable"))
		{
			int itemIndex = Array.IndexOf(inventoryItems, collision.gameObject);
			if (itemIndex >= 0)
				inventoryItems[itemIndex] = null;

			collision.gameObject.GetComponent<Draggable>().DefaultPosition = collision.gameObject.GetComponent<Draggable>().FirstPosition;
		}
	}

	Vector3 FindClosestFreeSlot(GameObject item)
	{
		int itemIndex = Array.IndexOf(inventoryItems, item);
		if (itemIndex >= 0)
			inventoryItems[itemIndex] = null;

		int index = -1;
		float minDistance = -1;
		for (int i = 0; i < inventoryItems.Length; ++i)
		{
			float distance = Vector2.Distance(item.transform.position, inventorySlots[i].transform.position);
			if (inventoryItems[i] is null && (distance < minDistance || minDistance < 0))
			{
				index = i;
				minDistance = distance;
			}
		}

		if (minDistance < 0)
			return item.GetComponent<Draggable>().DefaultPosition;
		else
		{
			inventoryItems[index] = item;
			return inventorySlots[index].transform.position;
		}
	}

	public void SwitchSide()
	{
		isRight = !isRight;
		movementDirection *= -1;
		cameraDistanceVector -= new Vector3(2 * (gameObject.transform.position.x - GameObject.FindWithTag("MainCamera").transform.position.x), 0);
		gameObject.transform.position -= new Vector3(2 * (gameObject.transform.position.x - GameObject.FindWithTag("MainCamera").transform.position.x), 0);
	}
}
