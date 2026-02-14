using UnityEngine;
using System.Collections.Generic;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] float CustomerSpawnOffset;
	[SerializeField] float CustomerSpawnTimer;
	[SerializeField] List<TableOrder> Tables;
    [SerializeField] GameObject CustomerPreset;
    float timer;
	System.Random rng = new();
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= CustomerSpawnTimer + rng.NextDouble() * CustomerSpawnOffset)
        {
            print("SPAWNING");
			CustomerData? customer = null;

			timer = 0;
            foreach (var t in Tables)
                if ((customer = t.GetCustomerSpot()) is not null) break;

            if (customer is null) return;

			GameObject spawned = Instantiate(CustomerPreset, gameObject.transform.position, Quaternion.identity);
			spawned.GetComponent<CustomerControl>().enabled = true;
			spawned.GetComponent<CustomerControl>().customer = (CustomerData)customer;

		}
	}
}
