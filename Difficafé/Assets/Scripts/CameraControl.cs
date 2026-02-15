using UnityEngine;

public class CameraControl : MonoBehaviour
{
	[SerializeField] float TrackingSpeedY;
	[SerializeField] float TopBound;
	[SerializeField] float BottomBound;
	void Update()
	{
        GameObject player = GameObject.FindWithTag("Player");
		float y = (player.transform.position.y - gameObject.transform.position.y) / 2;

		gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, y * TrackingSpeedY);

		if (gameObject.transform.position.y > TopBound)
		{
			gameObject.transform.position = new Vector3(gameObject.transform.position.x, TopBound, -10);
			gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
		} else if (gameObject.transform.position.y < BottomBound)
		{
			gameObject.transform.position = new Vector3(gameObject.transform.position.x, BottomBound, -10);
			gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
		}
	}
}
