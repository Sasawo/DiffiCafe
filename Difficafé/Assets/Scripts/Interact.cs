using UnityEngine;
using UnityEngine.Events;

public class Interact : MonoBehaviour
{
    [SerializeField] UnityEvent onInteract;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            onInteract?.Invoke();
        }
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
