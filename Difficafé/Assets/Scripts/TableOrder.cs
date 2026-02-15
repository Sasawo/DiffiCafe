using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static CustomerOrder;

public class CustomerOrder
{
	public enum CoffeeLayers { COFFEE, MILK, W_MILK }
	public enum Extras { STRAW, CREAM, SUGAR, TBD }
    public int CupSize;
    public CoffeeLayers[] Layers;
    public List<Extras> ExtraItems;

    public bool CompareOrders(Order other)
    {
        if (CupSize != other.CupSize) return false;

        if (Layers.Length != other.Layers.Length) return false;
        for (int i = 0; i < Layers.Length; ++i)
            if (Layers[i] != other.Layers[i]) return false;

        if (ExtraItems.Count != other.ExtraItems.Count) return false;
        foreach (Extras e in ExtraItems)
            if (!other.ExtraItems.Contains(e)) return false;

        return true;
    }
}

public class Order
{
	public int CupSize;
	public CoffeeLayers[] Layers;
	public List<Extras> ExtraItems;
}

[System.Serializable]
public class CustomerData
{
    public List<GameObject> SplinePoints;
    public CustomerOrder Order;
    public bool IsOccupied;
    public bool OrderTaken;
    public bool OrderDelivered;

    public void GenerateOrder()
    {
        System.Random rng = new();
        Order = new CustomerOrder();
        Order.CupSize = rng.Next(0, 2);
        Order.Layers = new CoffeeLayers[Order.CupSize];
        Order.ExtraItems = new();
        
        for (int i = 0; i < Order.Layers.Length; ++i)
            Order.Layers[i] = (CoffeeLayers)rng.Next(0, 2);

        int extrasCount = rng.Next(0, 3);
        List<int> extraItems = new List<int>() {0, 1, 2, 3 };
        extraItems.Shuffle();

		for (int i = 0; i < extrasCount; ++i)
            Order.ExtraItems.Add((Extras)extraItems[i]);

    }
}

public class TableOrder : MonoBehaviour
{
    [SerializeField] List<CustomerData> CustomerPaths;
    [SerializeField] int TableId;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public CustomerData? GetCustomerSpot()
    {
        CustomerPaths.Shuffle();

        for (int i = 0; i < CustomerPaths.Count; ++i)
        {
            if (!CustomerPaths[i].IsOccupied)
            {
                CustomerPaths[i].IsOccupied = true;
                CustomerPaths[i].GenerateOrder();
                return CustomerPaths[i];
            }
        }

        return null;
    }
}
