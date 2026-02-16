using UnityEngine;

public class Layerer : MonoBehaviour
{
    [SerializeField] int RenderAbove;
	[SerializeField] int RenderBelow;
	void Update()
    {
        if (GameObject.Find("Player").transform.position.y > transform.position.y)
            GetComponent<SpriteRenderer>().sortingOrder = RenderAbove;
        else
			GetComponent<SpriteRenderer>().sortingOrder = RenderBelow;
	}
}
