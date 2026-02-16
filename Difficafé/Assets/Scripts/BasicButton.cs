using System.Linq;
using UnityEngine;

public class BasicButton : MonoBehaviour
{
    [SerializeField] StaticInventory CupHolder;
    [SerializeField] StaticInventory SpoonHolder;
	[SerializeField] Sprite resetSprite;
	[SerializeField] int Layers;
	[SerializeField] bool forCoffee;

	private void OnMouseDown()
	{
		if (forCoffee)
		{
			if (CupHolder.inventoryItems[0].CompareTag("DraggableCup") &&
			SpoonHolder.inventoryItems[0].CompareTag("DraggableSpoon") && SpoonHolder.inventoryItems[0].GetComponent<SpriteRenderer>().sprite.name == "Coffee_spoon_pressed_0" &&
			CupHolder.inventoryItems[0].GetComponent<OrderBuilder>().order.CupSize >= Layers - 1)
			{
				SpoonHolder.inventoryItems[0].GetComponent<SpriteRenderer>().sprite = resetSprite;
				for (int i = 0; i < Layers; i++)
				{
					CupHolder.inventoryItems[0].GetComponent<OrderBuilder>().AddLayer(0);
				}
			}
			CupHolder.inventoryItems[0].GetComponent<OrderBuilder>().Render();
		} else
		{
			if (CupHolder.inventoryItems[0].CompareTag("DraggableJug") &&
			CupHolder.inventoryItems[0].GetComponent<SpriteRenderer>().sprite.name == "Milk_full_milk_jug")
				CupHolder.inventoryItems[0].GetComponent<SpriteRenderer>().sprite = resetSprite;
		}
	}
}
