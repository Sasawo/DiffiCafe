using UnityEngine;

public class Interact : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        gameObject.transform.Find("Interactable").GetComponent<SpriteRenderer>().enabled = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		gameObject.transform.Find("Interactable").GetComponent<SpriteRenderer>().enabled = false;
	}
}
