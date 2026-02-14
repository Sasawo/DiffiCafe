using UnityEngine;

public class PullButton : MonoBehaviour
{
    [SerializeField] float PullDistance;
    [SerializeField] float ReturnSpeed;
    float DefaultHeight;
    bool pressed;
    bool pulling;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DefaultHeight = gameObject.transform.position.y;
        pressed = false;
        pulling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed && pulling)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, (gameObject.transform.position.y + Camera.main.ScreenToWorldPoint(Input.mousePosition).y) / 2);
            if (gameObject.transform.position.y > DefaultHeight)
            {
				gameObject.transform.position = new Vector3(gameObject.transform.position.x, DefaultHeight);
			} else if (gameObject.transform.position.y < DefaultHeight - PullDistance)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, DefaultHeight - PullDistance);
                pulling = false;
			}
        } else if (!pressed)
        {
            if (gameObject.transform.position.y < DefaultHeight - 0.01)
                gameObject.transform.position += new Vector3(0, (DefaultHeight + 1 - gameObject.transform.position.y) / 2 * ReturnSpeed * Time.deltaTime);
            else
				gameObject.transform.position = new Vector3(gameObject.transform.position.x, DefaultHeight);

		}
    }

	private void OnMouseDown()
	{
        pulling = true;
        pressed = true;
	}

	private void OnMouseUp()
	{
		pressed = false;
	}
}
