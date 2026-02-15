using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class StaticInventory : MonoBehaviour
{
	[NonReorderable] public GameObject[] inventorySlots;
	[NonSerialized][NonReorderable] public GameObject[] inventoryItems;
	[SerializeField] List<string> AllowedTags;
	[SerializeField] int RenderLayer;
	[SerializeField] GameObject affected;
	[SerializeField] UnityEvent<GameObject, GameObject> OnPutDown;
	[SerializeField] UnityEvent<GameObject, GameObject> OnPickUp;
	[SerializeField] UnityEvent<GameObject> OnExtraAction;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		inventoryItems = new GameObject[inventorySlots.Length];
		Array.Fill(inventoryItems, null);
    }

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (AllowedTags.Contains(collision.gameObject.tag))
		{
			collision.gameObject.GetComponent<Draggable>().DefaultPosition = FindClosestFreeSlot(collision.gameObject);
			collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = RenderLayer;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (AllowedTags.Contains(collision.gameObject.tag))
		{
			int itemIndex = Array.IndexOf(inventoryItems, collision.gameObject);
			if (itemIndex >= 0)
				inventoryItems[itemIndex] = null;
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
			item.GetComponent<Draggable>().currentInventory = gameObject.GetComponent<StaticInventory>();
			return inventorySlots[index].transform.position;
		}
	}
	public void ObjectPutDown(GameObject o)
	{
		OnPutDown?.Invoke(o, affected);
	}
	public void ObjectPickedUp(GameObject o)
	{
		OnPickUp?.Invoke(o, affected);
	}
	public void ExtraAction()
	{
		OnExtraAction?.Invoke(gameObject);
	}
}
