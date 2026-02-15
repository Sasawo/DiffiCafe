using Unity.VectorGraphics;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuDelegates : MonoBehaviour
{
    public void PlayButton()
    {
		PlayerPrefs.SetInt("Day", 0);
		SceneManager.LoadScene("LoreScene");
	}

	public void ContinueButton()
	{
		if (!PlayerPrefs.HasKey("Day")) return;

		SceneManager.LoadScene("DayScene");
	}

	public void ExitButton()
    {
		//PlayerPrefs.DeleteAll();
		Application.Quit();
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false; // stops play mode in editor
#endif
	}
}
