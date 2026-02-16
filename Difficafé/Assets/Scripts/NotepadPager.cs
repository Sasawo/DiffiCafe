using UnityEngine;

public class NotepadPager : MonoBehaviour
{
    [SerializeField] int Increment;
    bool contains;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        contains = false;
    }

    public bool Check()
    {
		contains = GetComponent<BoxCollider2D>().OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        return contains;
	}

    public bool Contained()
    {
        bool contained = contains;
        contains = false;
        return contained;
	}

	private void OnMouseDown()
	{
        NotepadOrders orders = GameObject.Find("Notepad").GetComponent<NotepadOrders>();

		orders.CurrentIndex += Increment;
        orders.DisplayOrder();
	}
}

