using System;
using System.Diagnostics.Tracing;
using UnityEngine;

public class CustomerControl : MonoBehaviour
{
	float DeltaTimeCompensation = 400;
    [NonSerialized] public CustomerData customer;
	[SerializeField] float TrackingSpeed;
	[SerializeField] float SpeedDampening;
	[SerializeField] float AdditionalDampening;
	public enum CustomerState { SPAWN, IDLE, LEAVING, DONE };
    public CustomerState customerState;
	int currentSplineIndex;
	private void Awake()
	{
        customerState = CustomerState.SPAWN;
		currentSplineIndex = 1;
	}
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (customerState)
        {
            case CustomerState.SPAWN:
                MoveToIndex(customer.SplinePoints.Count - 1, 1);
                break;
			case CustomerState.IDLE:
				break;
            case CustomerState.LEAVING:
				MoveToIndex(0, -1);
                break;
			case CustomerState.DONE:
				break;
			default:
                break;
		}
    }
    void MoveToCurrentIndex()
    {
		Vector3 finalPos = customer.SplinePoints[currentSplineIndex].transform.position;

		gameObject.GetComponent<Rigidbody2D>().linearVelocity *= SpeedDampening;

		gameObject.GetComponent<Rigidbody2D>().linearVelocity +=
			new Vector2((finalPos.x - gameObject.transform.position.x) * TrackingSpeed, (finalPos.y - gameObject.transform.position.y) * TrackingSpeed) * AdditionalDampening * Time.deltaTime * DeltaTimeCompensation;
	}

    void MoveToIndex(int index, int increment)
    {
		MoveToCurrentIndex();

		if (Vector2.Distance(gameObject.transform.position, customer.SplinePoints[currentSplineIndex].transform.position) < 1)
        {
            if (currentSplineIndex == index && Vector2.Distance(gameObject.transform.position, customer.SplinePoints[currentSplineIndex].transform.position) < 0.1)
            {
                gameObject.transform.position = new Vector3(customer.SplinePoints[currentSplineIndex].transform.position.x, customer.SplinePoints[currentSplineIndex].transform.position.y, 0);
				gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;

				customerState = customerState + 1;
            } else if (currentSplineIndex != index)
            {
				currentSplineIndex += increment;
			}
		}
	}
	public void ProgressState()
	{
		++customerState;
	}


}
