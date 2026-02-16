using System;
using System.Linq;
using UnityEngine;
using static CustomerOrder;

public class InteractionDelegates : MonoBehaviour
{
	[SerializeField] GameObject cupPreset;
	[SerializeField] Sprite FullSpoon;
	[SerializeField] Sprite JugEmpty;
	[SerializeField] Sprite JugHalfMilk;
	[SerializeField] Sprite JugHalfWhipped;
	public void GoToCoffeeMachine(GameObject self)
	{
		GameObject.Find("CoffeeCamera").GetComponent<Camera>().enabled = true;
		GameObject.Find("MainCamera").GetComponent<Camera>().enabled = false;

		GameObject.Find("CoffeeCamera").tag = "MainCamera";
		GameObject.Find("MainCamera").tag = "Untagged";
	}

	public void ReturnFromCoffeeMachine(GameObject self)
	{
		GameObject.Find("CoffeeCamera").GetComponent<Camera>().enabled = false;
		GameObject.Find("MainCamera").GetComponent<Camera>().enabled = true;

		GameObject.Find("CoffeeCamera").tag = "Untagged";
		GameObject.Find("MainCamera").tag = "MainCamera";
	}

	public void GoToDecoTable(GameObject self)
	{
		GameObject.Find("DecoCamera").GetComponent<Camera>().enabled = true;
		GameObject.Find("MainCamera").GetComponent<Camera>().enabled = false;

		GameObject.Find("DecoCamera").tag = "MainCamera";
		GameObject.Find("MainCamera").tag = "Untagged";
	}

	public void ReturnFromDecoTable(GameObject self)
	{
		GameObject.Find("DecoCamera").GetComponent<Camera>().enabled = false;
		GameObject.Find("MainCamera").GetComponent<Camera>().enabled = true;

		GameObject.Find("DecoCamera").tag = "Untagged";
		GameObject.Find("MainCamera").tag = "MainCamera";
	}

	public void GoToKitchenTable(GameObject self)
	{
		GameObject.Find("KitchenCamera").GetComponent<Camera>().enabled = true;
		GameObject.Find("MainCamera").GetComponent<Camera>().enabled = false;

		GameObject.Find("KitchenCamera").tag = "MainCamera";
		GameObject.Find("MainCamera").tag = "Untagged";
	}

	public void ReturnFromKitchenTable(GameObject self)
	{
		GameObject.Find("KitchenCamera").GetComponent<Camera>().enabled = false;
		GameObject.Find("MainCamera").GetComponent<Camera>().enabled = true;

		GameObject.Find("KitchenCamera").tag = "Untagged";
		GameObject.Find("MainCamera").tag = "MainCamera";
	}

	public void MoveTray(GameObject self)
	{
		if (GameObject.Find("Tray").GetComponent<Inventory>().moving)
		{
			GameObject.Find("Tray").GetComponent<Inventory>().FlipDirection();
		} else
		{
			GameObject.Find("Tray").GetComponent<Inventory>().moving = true;
		}
	}

	public void GetTableOrder(GameObject self)
	{
		NotepadOrders notepad = GameObject.Find("Notepad").GetComponent<NotepadOrders>();
		var orders = self.GetComponent<TableOrder>().GetTableOrder();
		for (int i = 0; i < orders.Count; ++i)
		{
			notepad.Orders.Add(orders[i].Order);
			orders[i].OrderTaken = true;
		}
		notepad.DisplayOrder();
	}

	public void SpoonIntoMachine(GameObject spoon, GameObject spoonIn)
	{
		spoon.GetComponent<SpriteRenderer>().enabled = false;
		spoonIn.GetComponent<SpriteRenderer>().enabled = true;
	}

	public void SpoonOutOfMachine(GameObject spoon, GameObject spoonIn)
	{
		spoon.GetComponent<SpriteRenderer>().enabled = true;
		spoonIn.GetComponent<SpriteRenderer>().enabled = false;
	}
	public void CoffeeGrind(GameObject o, GameObject o2)
	{
		StaticInventory inventory = o.GetComponent<StaticInventory>();

		for (int i = 0; i < inventory.inventoryItems.Length; ++i)
		{
			if (inventory.inventoryItems[i].GetComponent<SpriteRenderer>().sprite.name == "Coffee_spoon_empty_0" && CoffeeMachineManager.Instance.GrinderUses > 0)
			{
				inventory.inventoryItems[i].GetComponent<SpriteRenderer>().sprite = FullSpoon;
				CoffeeMachineManager.Instance.GrinderUses -= 1;
			}
		}
	}
	public void SetStraw(GameObject o, GameObject o2)
	{
		o.GetComponent<OrderBuilder>().order.ExtraItems.Add(CustomerOrder.Extras.STRAW);
	}
	public void SetSugar(GameObject o, GameObject o2)
	{
		o.GetComponent<OrderBuilder>().order.ExtraItems.Add(CustomerOrder.Extras.SUGAR);
	}
	public void SetCinammon(GameObject o, GameObject o2)
	{
		o.GetComponent<OrderBuilder>().order.ExtraItems.Add(CustomerOrder.Extras.CINNAMON);
	}
	public void SetCream(GameObject o, GameObject o2)
	{
		o.GetComponent<OrderBuilder>().order.ExtraItems.Add(CustomerOrder.Extras.CREAM);
	}
	public void SetMilk(GameObject o, GameObject o2)
	{
		o.GetComponent<OrderBuilder>().AddLayer(1);
		o.GetComponent<OrderBuilder>().Render();
	}
	public void SetWMilk(GameObject o, GameObject o2)
	{
		o.GetComponent<OrderBuilder>().AddLayer(2);
		o.GetComponent<OrderBuilder>().Render();
	}
	public void ResetCup(GameObject o, GameObject o2)
	{
		Array.Fill(o.GetComponent<OrderBuilder>().order.Layers, (CoffeeLayers)3);
		o.GetComponent<OrderBuilder>().order.ExtraItems = new();
		o.GetComponent<OrderBuilder>().layersCount = 0;
		o.GetComponent<OrderBuilder>().Render();
	}
	public void SetFromJug(GameObject o, GameObject o2)
	{
		switch(o.GetComponent<SpriteRenderer>().sprite.name)
		{
			case "Milk_jug":
				return;
			case "Milk_half_milk_jug":
				if (o2.GetComponent<OrderBuilder>().AddLayer(1))
					o.GetComponent<SpriteRenderer>().sprite = JugEmpty;
				break;
			case "Milk_full_milk_jug":
				if (o2.GetComponent<OrderBuilder>().AddLayer(1))
					o.GetComponent<SpriteRenderer>().sprite = JugHalfMilk;
				break;
			case "Crema_half_milk_jug":
				if (o2.GetComponent<OrderBuilder>().AddLayer(2))
					o.GetComponent<SpriteRenderer>().sprite = JugEmpty;
				break;
			case "Crema_full_milk_jug":
				if (o2.GetComponent<OrderBuilder>().AddLayer(2))
					o.GetComponent<SpriteRenderer>().sprite = JugHalfWhipped;
				break;
		}
		o2.GetComponent<OrderBuilder>().Render();
	}
}
