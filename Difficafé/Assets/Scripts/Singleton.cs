using UnityEngine;
using System.Collections.Generic;

public class MySingleton : MonoBehaviour
{
	public static MySingleton Instance { get; private set; }
	[SerializeField] GameData gameData;

	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public int GetAllowedCupSize() => gameData.DAY_DATA[PlayerPrefs.GetInt("Day")].CupSizeCap;
	public int GetAllowedCustomerCount() => gameData.DAY_DATA[PlayerPrefs.GetInt("Day")].CustomerCount;
	public List<CustomerOrder.CoffeeLayers> GetAllowedLayers() => gameData.DAY_DATA[PlayerPrefs.GetInt("Day")].AllowedLayers;
	public List<CustomerOrder.Extras> GetAllowedExtras() => gameData.DAY_DATA[PlayerPrefs.GetInt("Day")].AllowedExtras;
}

