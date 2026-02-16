using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static CustomerOrder;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CustomerOrder
{
	public enum CoffeeLayers { COFFEE, MILK, W_MILK, NONE }
	public enum Extras { STRAW, CREAM, SUGAR, CINNAMON }
	public int OrderId;
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
    public CustomerControl Customer;
    public bool IsOccupied;
    public bool OrderTaken;
    int cutomersIds = 0;

    public void GenerateOrder(int id)
    {
        System.Random rng = new();
        Order = new CustomerOrder();
        Order.OrderId = id * 100 + cutomersIds++;
        Order.CupSize = rng.Next(0, MySingleton.Instance.GetAllowedCupSize());
        Order.Layers = new CoffeeLayers[Order.CupSize + 1];
		Array.Fill(Order.Layers, (CoffeeLayers)3);
		Order.ExtraItems = new();

        int layersCount = rng.Next(1, Order.CupSize + 2);
        for (int i = 0; i < layersCount; ++i)
        {
			CoffeeLayers layer = (CoffeeLayers)rng.Next(0, 3);
            while (!MySingleton.Instance.GetAllowedLayers().Contains(layer)) layer = (CoffeeLayers)rng.Next(0, 3);
            Order.Layers[i] = layer;
		}

        int extrasCount = Math.Min(rng.Next(0, 4), MySingleton.Instance.GetAllowedExtras().Count);
        List<int> extraItems = new List<int>() {0, 1, 2, 3 };
        extraItems.Shuffle();
        extraItems.RemoveAll(x => !MySingleton.Instance.GetAllowedExtras().Contains((Extras)x));

		for (int i = 0; i < extrasCount; ++i)
		    Order.ExtraItems.Add((Extras)extraItems[i]);
    }
}

public class TableOrder : MonoBehaviour
{
    [SerializeField] List<CustomerData> CustomerSpots;
    [SerializeField] int TableId;

    public CustomerData? GetCustomerSpot()
    {
		CustomerSpots.Shuffle();

        for (int i = 0; i < CustomerSpots.Count; ++i)
        {
            if (!CustomerSpots[i].IsOccupied)
            {
				CustomerSpots[i].IsOccupied = true;
				CustomerSpots[i].GenerateOrder(TableId);
                return CustomerSpots[i];
            }
        }

        return null;
    }

    public List<CustomerData> GetTableOrder() => CustomerSpots;
}
