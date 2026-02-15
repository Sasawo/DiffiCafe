using UnityEngine;

public class Grinder : MonoBehaviour
{
	private void Update()
	{
		if (CoffeeMachineManager.Instance.GrinderUses == 0)
		{
			GetComponent<SpriteRenderer>().enabled = false;
		} else
		{
			GetComponent<SpriteRenderer>().enabled = true;
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("DraggableBag") && CoffeeMachineManager.Instance.GrinderUses < 8) CoffeeMachineManager.Instance.GrinderUses = 8;
	}
}
