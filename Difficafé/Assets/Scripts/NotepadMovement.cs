using System;
using UnityEngine;

public class NotepadMovement : MonoBehaviour
{
	[NonSerialized] public bool moving;
    [SerializeField] float MovementDistance;
    [SerializeField] float MovementSpeed;
	[SerializeField] GameObject Up;
	[SerializeField] GameObject Down;
	int movementDirection = 1;
	float distanceMoved = 0;
	float basePos;
	private void Awake()
	{
		basePos = gameObject.transform.position.y - GameObject.Find("Tray").transform.position.y;
	}
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        moving = false;
	}

    // Update is called once per frame
    void LateUpdate()
    {
		if (moving && distanceMoved < MovementDistance)
		{
			GameObject.Find("Jug2").GetComponent<BoxCollider2D>().enabled = true;
			GameObject.Find("WhippedCream").GetComponent<BoxCollider2D>().enabled = true;
			gameObject.transform.position += new Vector3(0, movementDirection * MovementSpeed * Time.deltaTime, 0);
			distanceMoved += MovementSpeed * Time.deltaTime;
		}
		else if (moving)
		{
			moving = false;
			movementDirection *= -1;
			gameObject.transform.position += new Vector3(0, -Mathf.Abs(distanceMoved - MovementDistance) * movementDirection, 0);
			
			if (movementDirection == 1)
				gameObject.transform.position = new Vector3(gameObject.transform.position.x, GameObject.Find("Tray").transform.position.y + basePos, gameObject.transform.position.z);
			else
			{
				GameObject.Find("Jug2").GetComponent<BoxCollider2D>().enabled = false;
				GameObject.Find("WhippedCream").GetComponent<BoxCollider2D>().enabled = false;
			}

				distanceMoved = 0;
		}
	}

	void FlipDirection()
	{
		movementDirection *= -1;
		distanceMoved = MovementDistance - distanceMoved;
	}
	private void OnMouseEnter()
	{
		if (Up.GetComponent<NotepadPager>().Contained() || Down.GetComponent<NotepadPager>().Contained()) return;

		if (moving) FlipDirection();
		moving = true;
	}

	private void OnMouseExit()
	{
		if (Up.GetComponent<NotepadPager>().Check() || Down.GetComponent<NotepadPager>().Check()) return;

		if (moving) FlipDirection();
		moving = true;
	}
}
