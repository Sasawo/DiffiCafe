using System;
using UnityEngine;

public class CoffeeMachineManager : MonoBehaviour
{
	public static CoffeeMachineManager Instance { get; private set; }
	[NonSerialized] public int GrinderUses;

	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
		GrinderUses = 0;
	}
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
