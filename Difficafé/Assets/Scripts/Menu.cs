using UnityEngine;

public class Menu : MonoBehaviour
{
	[SerializeField] AudioClip clip;
	[SerializeField] float volume = 1;
    void Start()
    {
		AudioManager.Instance.StopSound();
		AudioManager.Instance.PlaySound(clip, true, volume);
	}
}
