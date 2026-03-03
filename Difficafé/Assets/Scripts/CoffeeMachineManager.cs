using System;
using UnityEngine;

public class CoffeeMachineManager : MonoBehaviour
{
	public static CoffeeMachineManager Instance { get; private set; }
	[NonSerialized] public int GrinderUses;
	[NonSerialized] public bool draggableIsActive;
	[NonSerialized] public bool currentlyDragging;

	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
		GrinderUses = 0;
		draggableIsActive = true;
		currentlyDragging = false;
	}
}
