using UnityEngine;

public class MenuDelegates : MonoBehaviour
{
    public void PlayButton()
    {

    }

	public void ContinueButton()
	{

	}

	public void ExitButton()
    {
		Application.Quit();
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false; // stops play mode in editor
#endif
	}
}
