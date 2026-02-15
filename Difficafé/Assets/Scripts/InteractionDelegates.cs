using UnityEngine;

public class InteractionDelegates : MonoBehaviour
{
	[SerializeField] GameObject cupPreset;
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
}
