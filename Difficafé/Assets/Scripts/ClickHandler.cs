using UnityEngine;

public interface IClickable
{
    void OnClick();
}
public class ClickHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos, Vector2.zero);

			System.Array.Sort(hits, (a, b) =>
			{
				var srA = a.collider.gameObject.GetComponent<SpriteRenderer>() == null ? -10 : a.collider.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
				var srB = b.collider.gameObject.GetComponent<SpriteRenderer>() == null ? -10 : b.collider.gameObject.GetComponent<SpriteRenderer>().sortingOrder;

				return srB - srA;
			});

			foreach (var hit in hits)
			{
				var clickable = hit.collider.GetComponent<IClickable>();

				if (clickable != null)
				{
					clickable.OnClick();
					break;
				}
			}
		}
	}
}
