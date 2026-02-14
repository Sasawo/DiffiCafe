using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Draggable : MonoBehaviour
{
	float DeltaTimeCompensation = 400;
	[NonSerialized] public Vector3 DefaultPosition;
	[NonSerialized] public Vector3 FirstPosition;
	[SerializeField] float TrackingSpeed;
	[SerializeField] float SpeedDampening;
	[SerializeField] float AdditionalDampening;
	bool returning;
	[NonSerialized] public bool dragging;
	void Start()
    {
		returning = false;
    }

    // Update is called once per frame
    void Update()
    {
		if (!dragging) return;

		if (Vector3.Distance(gameObject.transform.position, DefaultPosition) < 0.5 && returning)
		{
			if (DefaultPosition == FirstPosition)
				Destroy(gameObject);

			returning = false;
			dragging = false;
			gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
			gameObject.transform.position = DefaultPosition;
			return;
		}

		if (Input.GetMouseButtonUp(0))
			returning = true;

		Vector3 finalPos;

		if (returning)
		{
			finalPos = DefaultPosition;
		} else
		{
			finalPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}

		gameObject.GetComponent<Rigidbody2D>().linearVelocity *= SpeedDampening;

		gameObject.GetComponent<Rigidbody2D>().linearVelocity += 
			new Vector2((finalPos.x - gameObject.transform.position.x) * TrackingSpeed, (finalPos.y - gameObject.transform.position.y) * TrackingSpeed) * AdditionalDampening * Time.deltaTime * DeltaTimeCompensation;
	}
}
