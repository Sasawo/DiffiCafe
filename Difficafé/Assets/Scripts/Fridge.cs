using UnityEngine;

public class Fridge : MonoBehaviour, IClickable
{
    [SerializeField] GameObject Milk;

	public void OnClick()
	{
		GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
		Milk.SetActive(!Milk.activeSelf);
	}
}
