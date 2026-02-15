using UnityEngine;

public class InteractionDelegates : MonoBehaviour
{
	[SerializeField] GameObject cupPreset;
	public void GoToCoffeeMachine()
	{
		GameObject.Find("CoffeeCamera").GetComponent<Camera>().enabled = true;
		GameObject.Find("MainCamera").GetComponent<Camera>().enabled = false;

		GameObject.Find("CoffeeCamera").tag = "MainCamera";
		GameObject.Find("MainCamera").tag = "Untagged";
	}

	public void ReturnFromCoffeeMachine()
	{
		GameObject.Find("CoffeeCamera").GetComponent<Camera>().enabled = false;
		GameObject.Find("MainCamera").GetComponent<Camera>().enabled = true;

		GameObject.Find("CoffeeCamera").tag = "Untagged";
		GameObject.Find("MainCamera").tag = "MainCamera";
	}

	public void GoToDecoTable()
	{
		GameObject.Find("DecoCamera").GetComponent<Camera>().enabled = true;
		GameObject.Find("MainCamera").GetComponent<Camera>().enabled = false;

		GameObject.Find("DecoCamera").tag = "MainCamera";
		GameObject.Find("MainCamera").tag = "Untagged";
	}

	public void ReturnFromDecoTable()
	{
		GameObject.Find("DecoCamera").GetComponent<Camera>().enabled = false;
		GameObject.Find("MainCamera").GetComponent<Camera>().enabled = true;

		GameObject.Find("DecoCamera").tag = "Untagged";
		GameObject.Find("MainCamera").tag = "MainCamera";
	}

	public void MoveTray()
	{
		if (GameObject.Find("Tray").GetComponent<Inventory>().moving)
		{
			GameObject.Find("Tray").GetComponent<Inventory>().FlipDirection();
		} else
		{
			GameObject.Find("Tray").GetComponent<Inventory>().moving = true;
		}
	}
}
