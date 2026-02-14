using UnityEngine;

public class RotateButton : MonoBehaviour
{
    [SerializeField] bool DirectionLeft;
    [SerializeField] float DegreeBound;
    [SerializeField] bool ReturnAction;
    bool pressed;
    bool rotating;
    float startAngle;
    float endAngle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pressed = false;
        rotating = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed && rotating)
        {
            float angle = GetAngle(gameObject.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
            print($"{startAngle} {endAngle}");
			if (IsInRange(angle))
            {
				gameObject.transform.Rotate(0, 0, angle - startAngle - gameObject.transform.eulerAngles.z);
                if (Mathf.Abs(angle - endAngle) < 5)
				{
					gameObject.transform.eulerAngles = new Vector3(0, 0, DirectionLeft ? -DegreeBound : DegreeBound);
					print("correct");
					rotating = false;
				}
			} else
            {
                SetupAngles();
			}
        } else if (!pressed && Mathf.Abs(gameObject.transform.eulerAngles.z - startAngle) > 2 && ReturnAction)
		{
            /*gameObject.transform.Rotate(0, 0, (gameObject.transform.eulerAngles.z - startAngle) / 3);
			if (gameObject.transform.eulerAngles.z > startAngle - 1 && gameObject.transform.eulerAngles.z < startAngle + 1)
				gameObject.transform.eulerAngles = new Vector3(0, 0, startAngle);*/
		}

	}

    float GetAngle(Vector2 pos1, Vector2 pos2)
    {
		Vector2 dir = pos1 - pos2;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

		if (angle < 0)
			angle += 360f;

		return angle;
	}

    void SetupAngles()
    {
		startAngle = GetAngle(gameObject.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
		endAngle = DirectionLeft ? startAngle - DegreeBound : startAngle + DegreeBound;
		while (endAngle < 0) endAngle += 360;
		while (endAngle >= 360) endAngle -= 360;
	}

	private void OnMouseDown()
	{
		SetupAngles();
		pressed = true;
        rotating = true;
	}

    bool IsInRange(float angle)
    {
        if (DirectionLeft)
            return angle >= startAngle && angle <= endAngle;
        else
            return angle <= startAngle || angle >= endAngle;
    }

	private void OnMouseUp()
    {
		pressed = false;
	}
}
