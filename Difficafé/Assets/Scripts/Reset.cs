using UnityEngine;
using UnityEngine.Events;

public class Reset : MonoBehaviour
{
	[SerializeField] Sprite resetTo;
	[SerializeField] Sprite resetFrom;
	[SerializeField] string allowedTag;
	[SerializeField] bool resetSelf;
	[SerializeField] GameObject affected;
	[SerializeField] UnityEvent<GameObject, GameObject> ExtraAction;


	GameObject contained;  // object currently over trigger

	private void OnTriggerEnter2D(Collider2D collision)
	{
		// Only track allowed objects
		if (collision.gameObject.CompareTag(allowedTag))
		{
			print("inside");
			contained = collision.gameObject;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject == contained)
		{
			contained = null;
		}
	}

	private void LateUpdate()
	{
		// Check if mouse released while object is over trigger
		if (contained != null && Input.GetMouseButtonUp(0))
		{
			if (resetSelf)
			{
				var sr = GetComponent<SpriteRenderer>();
				if (resetFrom == null || sr.sprite == resetFrom)
					sr.sprite = resetTo;
			}
			else
			{
				var sr = contained.GetComponent<SpriteRenderer>();
				if (resetFrom == null || sr.sprite == resetFrom)
					sr.sprite = resetTo;
			}

			if (affected == null) affected = contained;

			ExtraAction?.Invoke(affected, gameObject);

			contained = null;
		}
	}
}
