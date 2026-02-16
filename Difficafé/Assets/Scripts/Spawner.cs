using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject toSpawn;
	private void OnMouseDown()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		GameObject spawned = Instantiate(toSpawn, new Vector3(mousePos.x, mousePos.y, 0), Quaternion.identity);
		spawned.GetComponent<Draggable>().enabled = true;
		spawned.GetComponent<Draggable>().DefaultPosition = spawned.transform.position;
		spawned.GetComponent<Draggable>().FirstPosition = spawned.transform.position;
		spawned.GetComponent<Draggable>().dragging = true;
		GameObject.Find("Notepad").GetComponent<NotepadMovement>().enabled = false;
		AudioManager.Instance.PlaySound(Resources.Load<AudioClip>("Audio/PickUp"), false, 0.1f);
	}
}
