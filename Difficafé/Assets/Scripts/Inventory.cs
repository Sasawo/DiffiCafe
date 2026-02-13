using UnityEngine;

public class Inventory : MonoBehaviour
{
	Vector3 cameraDistanceVector = new Vector3();
	Vector3 baseDistanceVector = new Vector3();

	[SerializeField] float movementSpeed;
	[SerializeField] float movementDistance;
	public bool moving;
    int movementDirection = -1;
	float distanceMoved = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		gameObject.transform.position += new Vector3(movementDistance, 0);
        moving = false;

        cameraDistanceVector = gameObject.transform.position - GameObject.FindWithTag("MainCamera").transform.position;
		baseDistanceVector = cameraDistanceVector;
	}

    // Update is called once per frame
    void LateUpdate()
    {
		gameObject.transform.position = GameObject.FindWithTag("MainCamera").transform.position + cameraDistanceVector;

		if (moving && distanceMoved < movementDistance)
        {
			gameObject.transform.position += new Vector3(movementDirection * movementSpeed, 0);
			distanceMoved += movementSpeed;
			cameraDistanceVector = gameObject.transform.position - GameObject.FindWithTag("MainCamera").transform.position;
		}
        else if (moving)
        {
            moving = false;
			movementDirection *= -1;
			gameObject.transform.position = new Vector3(Mathf.Abs(distanceMoved - movementDistance) * movementDirection, 0);
			distanceMoved = 0;
		}

		gameObject.transform.position = GameObject.FindWithTag("MainCamera").transform.position + cameraDistanceVector;
	}
}
