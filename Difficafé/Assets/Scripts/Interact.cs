using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Events;

public class Interact : MonoBehaviour
{
	[SerializeField] UnityEvent onInteract;
	[SerializeField] UnityEvent onReturnInteract;
	[SerializeField] bool InteractOnTouch;
	[SerializeField] bool InventoryRight;
	bool active = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && active)
        {
			GameObject.Find("Player").GetComponent<PlayerControl>().enabled = !GameObject.Find("Player").GetComponent<PlayerControl>().enabled;
			GameObject.Find("Player").GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
			GameObject.Find("Player").GetComponent<PlayerControl>().movementVector = Vector2.zero;

			RunInteract();

		}
    }

	void RunInteract()
	{
		if (InventoryRight != GameObject.Find("Tray").GetComponent<Inventory>().isRight) GameObject.Find("Tray").GetComponent<Inventory>().SwitchSide();

		onInteract?.Invoke();

		UnityEvent temp = onInteract;
		onInteract = onReturnInteract;
		onReturnInteract = temp;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (InteractOnTouch)
		{
			RunInteract();
			return;
		}
        gameObject.transform.Find("Interactable").GetComponent<SpriteRenderer>().enabled = true;
        active = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (InteractOnTouch)
		{
			RunInteract();
			return;
		}
		gameObject.transform.Find("Interactable").GetComponent<SpriteRenderer>().enabled = false;
		active = false;
	}
}
