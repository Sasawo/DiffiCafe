using System;
using UnityEngine;

public class NotepadMovement : MonoBehaviour
{
	Vector3 notepadDistanceVector = new();

	[NonSerialized] public bool moving;
    [SerializeField] float MovementDistance;
    [SerializeField] float MovementSpeed;
	int movementDirection = 1;
	float distanceMoved = 0;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        moving = false;
		notepadDistanceVector = gameObject.transform.position - GameObject.Find("Tray").transform.position;
	}

    // Update is called once per frame
    void LateUpdate()
    {
		gameObject.transform.position = GameObject.Find("Tray").transform.position + notepadDistanceVector;

		if (moving && distanceMoved < MovementDistance)
		{
			gameObject.transform.position += new Vector3(0, movementDirection * MovementSpeed);
			distanceMoved += MovementSpeed;
			notepadDistanceVector = gameObject.transform.position - GameObject.Find("Tray").transform.position;
		}
		else if (moving)
		{
			moving = false;
			movementDirection *= -1;
			gameObject.transform.position += new Vector3(
				gameObject.transform.position.x,
				gameObject.transform.position.y - Mathf.Abs(distanceMoved - MovementDistance) * movementDirection);
			distanceMoved = 0;
		}

		gameObject.transform.position = GameObject.Find("Tray").transform.position + notepadDistanceVector;
	}

	void FlipDirection()
	{
		movementDirection *= -1;
		distanceMoved = MovementDistance - distanceMoved;
	}
	private void OnMouseEnter()
	{
		if (moving) FlipDirection();
		moving = true;
	}

	private void OnMouseExit()
	{
		if (moving) FlipDirection();
		moving = true;
	}
}
