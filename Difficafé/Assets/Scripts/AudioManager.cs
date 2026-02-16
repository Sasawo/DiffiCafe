using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance { get; private set; }
	AudioSource[] sources;

	void Awake()
	{
		sources = GetComponents<AudioSource>();

		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public void PlaySound(AudioClip play, bool loop, float volume = 1)
	{
		foreach (AudioSource source in sources)
		{
			if (!source.isPlaying)
			{
				source.loop = loop;
				source.clip = play;
				source.volume = volume;
				source.Play();
				return;
			}
		}
	}
	public void StopSound()
	{
		foreach (AudioSource source in sources)
			source.Stop();
	}
}
