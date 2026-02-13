using UnityEngine;

public class CameraControl : MonoBehaviour
{
	[SerializeField] float TrackingSpeedX;
	[SerializeField] float TrackingSpeedY;
	void Update()
	{
        GameObject player = GameObject.FindWithTag("Player");

        float x = (player.transform.position.x - gameObject.transform.position.x) / 2;
		float y = (player.transform.position.y - gameObject.transform.position.y) / 2;

		gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(x * TrackingSpeedX, y * TrackingSpeedY);
	}
}
