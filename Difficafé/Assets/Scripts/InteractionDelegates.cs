using UnityEngine;

public class InteractionDelegates : MonoBehaviour
{
    public void GoToCoffeeMachine()
    {
        GameObject.Find("CoffeeCamera").GetComponent<Camera>().enabled = true;
		GameObject.Find("MainCamera").GetComponent<Camera>().enabled = false;
	}

	public void GoToDecoTable()
	{
		GameObject.Find("DecoCamera").GetComponent<Camera>().enabled = true;
		GameObject.Find("MainCamera").GetComponent<Camera>().enabled = false;
	}
}
