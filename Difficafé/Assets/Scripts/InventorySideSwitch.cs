using UnityEngine;

public class InventorySideSwitch : MonoBehaviour
{
	private void OnTriggerEnter2D()
	{
		GameObject.Find("Tray").GetComponent<Inventory>().SwitchSide();
	}

	private void OnTriggerExit2D()
	{
		GameObject.Find("Tray").GetComponent<Inventory>().SwitchSide();
	}
}
