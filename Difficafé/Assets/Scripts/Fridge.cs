using UnityEngine;

public class Fridge : MonoBehaviour
{
    [SerializeField] GameObject Milk;

	private void OnMouseDown()
	{
		GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
        Milk.SetActive(!Milk.activeSelf);
	}
}
