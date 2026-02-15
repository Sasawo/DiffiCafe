using UnityEngine;

public class MySingleton : MonoBehaviour
{
	public static MySingleton Instance { get; private set; }
	[SerializeField] GameData gameData;

	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject); // only one instance allowed
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject); // survives scene changes
	}
}

