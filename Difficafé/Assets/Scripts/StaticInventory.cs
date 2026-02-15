using System;
using System.Collections;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class StaticInventory : MonoBehaviour
{
	[NonReorderable] public GameObject[] inventorySlots;
	[NonSerialized][NonReorderable] public GameObject[] inventoryItems;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		inventoryItems = new GameObject[inventorySlots.Length];
		Array.Fill(inventoryItems, null);
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
}
