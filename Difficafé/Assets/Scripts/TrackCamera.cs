using UnityEngine;

public class TrackCamera : MonoBehaviour
{
    Vector3 cameraDistanceVector = new Vector3();
    Vector3 baseDistanceVector = new Vector3();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraDistanceVector = gameObject.transform.position - GameObject.FindWithTag("MainCamera").transform.position;
        baseDistanceVector = cameraDistanceVector;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = GameObject.FindWithTag("MainCamera").transform.position + cameraDistanceVector;
    }

    public void UpdateOffset()
    {
        cameraDistanceVector = gameObject.transform.position - GameObject.FindWithTag("MainCamera").transform.position;
	}
}
