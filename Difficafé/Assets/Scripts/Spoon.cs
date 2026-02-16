using UnityEngine;

public class Spoon : MonoBehaviour
{
    [SerializeField] Sprite Pressed;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("DraggablePresser") && GetComponent<SpriteRenderer>().sprite.name == "Coffee_spoon_full_0")
			GetComponent<SpriteRenderer>().sprite = Pressed;
	}
}
