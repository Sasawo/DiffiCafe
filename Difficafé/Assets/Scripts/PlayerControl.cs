using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	[SerializeField] float MovementSpeed;

	public Vector2 movementVector = Vector2.zero;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		gameObject.GetComponent<Rigidbody2D>().linearVelocity = GetMovementAndNormalize();
	}

	Vector2 GetMovementAndNormalize()
	{
		if (Input.GetKeyUp(KeyCode.W) && movementVector.y > 0)
		{
			movementVector.y -= 1;
		}
		if (Input.GetKeyUp(KeyCode.S) && movementVector.y < 0)
		{
			movementVector.y += 1;
		}
		if (Input.GetKeyUp(KeyCode.A) && movementVector.x < 0)
		{
			movementVector.x += 1;
		}
		if (Input.GetKeyUp(KeyCode.D) && movementVector.x > 0)
		{
			movementVector.x -= 1;
		}


		if (Input.GetKeyDown(KeyCode.W) && movementVector.y == 0)
		{
			movementVector.y += 1;
		}
		if (Input.GetKeyDown(KeyCode.S) && movementVector.y == 0)
		{
			movementVector.y -= 1;
		}
		if (Input.GetKeyDown(KeyCode.A) && movementVector.x == 0)
		{
			movementVector.x -= 1;
		}
		if (Input.GetKeyDown(KeyCode.D) && movementVector.x == 0)
		{
			movementVector.x += 1;
		}

		Vector2 tempMovement = movementVector;

		tempMovement.Normalize();
		return tempMovement * MovementSpeed;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
	}
}
