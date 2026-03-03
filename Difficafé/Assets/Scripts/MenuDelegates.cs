using Unity.VectorGraphics;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuDelegates : MonoBehaviour
{
    public void PlayButton()
    {
		PlayerPrefs.SetInt("Day", 1);
		PlayerPrefs.SetInt("Infinite", 0);
		SceneManager.LoadScene("LoreScene");
	}

	public void ContinueButton()
	{
		if (!PlayerPrefs.HasKey("Day")) return;
		PlayerPrefs.SetInt("Infinite", 0);
		SceneManager.LoadScene("DayScene");
	}

	public void ExitButton()
    {
		PlayerPrefs.DeleteAll();
		Application.Quit();
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false; // stops play mode in editor
#endif
	}

	public void InfiniteButton()
	{
		PlayerPrefs.SetInt("Infinite", 1);
		SceneManager.LoadScene("InfiniteLoreScene");
	}
}
