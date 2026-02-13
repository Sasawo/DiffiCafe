using UnityEngine;

public class CameraControl : MonoBehaviour
{
	[SerializeField] float TrackingSpeedX;
	[SerializeField] float TrackingSpeedY;
	void Update()
	{
        GameObject player = GameObject.FindWithTag("Player");
		float y = (player.transform.position.y - gameObject.transform.position.y) / 2;

		gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, y * TrackingSpeedY);
	}
}
