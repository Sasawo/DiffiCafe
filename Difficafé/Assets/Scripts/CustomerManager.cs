using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] float CustomerSpawnOffset;
	[SerializeField] float CustomerSpawnTimer;
	[SerializeField] List<TableOrder> Tables;
    [SerializeField] GameObject CustomerPreset;
    List<GameObject> currentCustomers;
    int spawnedCount;
    int finishedCount;
    float timer;
	System.Random rng = new();
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        currentCustomers = new();
		timer = 0;
		spawnedCount = 0;
		finishedCount = 0;

	}

    // Update is called once per frame
    void Update()
    {
        if (finishedCount == MySingleton.Instance.GetAllowedCustomerCount()) SceneManager.LoadScene("EveScene");

        for (int i = currentCustomers.Count - 1; i >= 0; --i)
        {
            if (currentCustomers[i].GetComponent<CustomerControl>().customerState == CustomerControl.CustomerState.DONE)
            {
                ++finishedCount;
                currentCustomers.RemoveAt(i);
            }
        }

        timer += Time.deltaTime;

        if (timer >= CustomerSpawnTimer + rng.NextDouble() * CustomerSpawnOffset && spawnedCount < MySingleton.Instance.GetAllowedCustomerCount())
        {
			CustomerData? customer = null;

			timer = 0;
            foreach (var t in Tables)
                if ((customer = t.GetCustomerSpot()) is not null) break;

            if (customer is null) return;

			GameObject spawned = Instantiate(CustomerPreset, gameObject.transform.position, Quaternion.identity);
            ++spawnedCount;
			spawned.GetComponent<CustomerControl>().enabled = true;
			spawned.GetComponent<CustomerControl>().customer = customer;
            customer.Customer = spawned.GetComponent<CustomerControl>();
            AudioManager.Instance.PlaySound(Resources.Load<AudioClip>("Audio/CustomerEnter"), false);
            currentCustomers.Add(spawned);
		}
	}
}
