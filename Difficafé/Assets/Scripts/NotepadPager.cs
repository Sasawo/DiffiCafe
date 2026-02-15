using UnityEngine;

public class NotepadPager : MonoBehaviour
{
    bool contains;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        contains = false;
    }

    // Update is called once per frame
    void Update()
    {

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
}

